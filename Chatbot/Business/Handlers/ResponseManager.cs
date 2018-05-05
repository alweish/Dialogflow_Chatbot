using Chatbot.Business.Mapper;
using Chatbot.Business.Repository;
using Chatbot.Business.Repository.DAL;
using Chatbot.Models;
using JaneBot;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chatbot.Business.Handlers {
    public class ResponseManager {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(ResponseManager));
        private readonly DAL _dal;

        public ResponseManager(IRepositoryInitialiser intialiser) {
            _dal = new DAL(intialiser);
        }

        public List<string> Response() {
            List<string> test = new List<string>(new string[] { "Welkom bij JaneBot", "Gelieve via de chatfunctie met mij te praten", "Ik help u graag verder " });
            return test;
        }


        public WebhookResponse CreateResponse(Response data) {
            string fullfilment = data.Message;
            var output = FulfillmentMessages(data);
            WebhookResponse response = new WebhookResponse() { fulfillmentText = fullfilment, fulfillmentMessages = output, source = null, followupEventInput = null, outputContexts = null, payload = null };

            return response;
        }

        private object FulfillmentMessages(Response data) {
            if (data.Parameter.flow == null) {
                var flows = _dal.GetAllFlows();
                return FulfillmentMessages(flows);
            }
            return null;
        }

        private FulFillmentMessage FulfillmentMessages(IList<Flow> flows) {
            List<Button> buttons = new List<Button>();
            foreach (var flow in flows) {
                buttons.Add(new Button() { text = flow.Name, postback = flow.Name });
            }
            FulFillmentMessage message = new FulFillmentMessage() {
                title = "test",
                buttons = buttons
            };
            return message;
        }
    }
}