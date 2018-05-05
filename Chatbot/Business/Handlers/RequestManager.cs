using Chatbot.Business.Repository;
using Chatbot.Business.Repository.DAL;
using Chatbot.Models;
using JaneBot;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using Postal;
using Chatbot.Business.Mapper;

namespace Chatbot.Business.Handlers {
    public class RequestManager {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(RequestManager));
        private readonly DAL _dal;

        public RequestManager(IRepositoryInitialiser intialiser) {
            _dal = new DAL(intialiser);
        }

        public Response ProcessRequest(Dictionary<string, string> param) {
            var numberofParams = param.Count;
            var data = Helper.Helper.GetObject(param);
            if (data == null) {
                return null;
            }
            var request = ModelMapper.MapToRequest(data);
            //TODO verschillend van vandaag, klant kan meerdere keren fouten creeeren
            var userRequest = GetUserRequest(request.Email);
            if (userRequest == null) {
                var id = _dal.CreateRequest(request);
                if (id > 0) {
                    Logger.Info($"Inserted Request");
                    var name = data.lastName;
                    if (data.firstName != null)
                        name = data.firstName;
                    return new Response() { Message = $"Waarmee kan ik u helpen {name} ?", Parameter = data, TicketSent = false };
                } else {
                    Logger.Info("Could not insert request");
                    return null;
                }
            }
            if (data.flow != null && data.flowDetail != null) {
                Logger.Info($"Update Request {userRequest.Id} with flow");
                userRequest.FlowDetail = data.flowDetail;
                userRequest.Flow = data.flow;
                _dal.UpdateRequest(userRequest);
                return FollowFlow(data);
            }

            return null;

        }

        private Parameter checkParameters(Parameter data) {
            return null;
        }

        private Response FollowFlow(Parameter data) {
            var ticketSent = false;
            switch (data.flow) {
                case Constant.Constants.Flow_Infrastructure:
                    ticketSent = GenerateGeneralTicket(data);
                    break;
                case Constant.Constants.Flow_Invoice:
                    if (data.flowDetail == "duplicaat") {
                        ticketSent = GetInvoice(data);
                    } else if (data.flowDetail == "facturatie_andere" & data.extraInfo != null) {
                        ticketSent = GenerateGeneralTicket(data);
                    }
                    break;
                case Constant.Constants.Flow_Other:
                    ticketSent = GenerateGeneralTicket(data);
                    break;

                default:
                    return new Response() { Message = "Something went wrong, the programmers code did something weird, please try again.", Parameter = data, TicketSent = ticketSent };
            }

            return new Response() { Message = "Een collega zal contact met je opnemen.", Parameter = data, TicketSent = ticketSent };
        }

        private bool GenerateGeneralTicket(Parameter data) {
            var flowId = _dal.GetFlowByName(data.flow).Id;
            var flowDetailId = _dal.GetFlowDetailByName(data.flowDetail).Id;
            var request = _dal.GetRequestByUserEmail(data.email);

            Ticket ticket = new Ticket() {
                DateReceived = DateTime.Now,
                FlowDetailId = flowDetailId,
                FlowId = flowId,
                ExtraInfo = data.extraInfo,
                UserId = request.Id
            };

            int id = _dal.CreateTicket(ticket);
            var mailsent = SendMail(data);
            if (mailsent && id > 0) {
                request.Processed = DateTime.Now;
                _dal.UpdateRequest(request);
                return true;
            }
            return false;
        }

        private Request GetUserRequest(string email) {
            return _dal.GetRequestByUserEmail(email);
        }


        public bool GetInvoice(Parameter data) {
            if (data.factuurNummer == null) {
                return false;
            }
            var invoice = Int32.Parse(data.factuurNummer);

            var request = _dal.GetRequestByUserEmail(data.email);
            var mailsent = SendMail(data);
            if (mailsent) {
                request.Processed = DateTime.Now;
                _dal.UpdateRequest(request);
                return true;
            }
            return false;
        }


        private bool SendMail(Parameter obj) {
            dynamic Email;
            if (obj.factuurNummer != null && obj.flow == "facturatie") {
                Email = new Email("Invoice");
                CreateInvoiceEmail(Email, obj);
            } else {
                Email = new Email("Ticket");
            }

            Email.From = "support@starringjane.com";
            Email.UserInfo = Mapper.ModelMapper.MapToUserInfo(obj);


            //TODO meer info user -> 2 tabellen -> request & userId

            if (Regex.IsMatch(obj.email, Constant.Constants.RegExEmail, RegexOptions.IgnoreCase)) {
                Email.To = "bluepizza2511@gmail.com";
            } else {
                //TODO, tussen berichten testen of reg -> anders text of doet dialogflow dit zelf?
                Logger.Info("Non reg email");
            }

            try {
                Email.Send();
                Logger.Info($"Email sent to {Email.To}");

            } catch (Exception ex) {
                Logger.Error($"Unable to send email: {ex.Message}\r\n{ex.StackTrace}");
                return false;
            }
            return true;
        }

        private dynamic CreateInvoiceEmail(dynamic email, Parameter obj) {
            email.Invoice = obj.factuurNummer;
            email.InvoiceDate = obj.factuurDatum;
            return email;
        }
    }
}