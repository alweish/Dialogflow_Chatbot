using Chatbot.Models;
using JaneBot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chatbot.Business.Mapper {
    public class ModelMapper {
        public static Request MapToRequest(Parameter parameter) {
            return new Request() {
                FirstName = parameter.firstName,
                LastName = parameter.lastName,
                Email = parameter.email,
                Flow = parameter.flow,
                DateCreated = DateTime.Now,
                FlowDetail = parameter.flowDetail
            };
        }
        public static WebhookResponse MapToReponse(string fullfilment, object output) {
            return new WebhookResponse() {
                followupEventInput = null,
                fulfillmentMessages = null,
                fulfillmentText = fullfilment,
                outputContexts = null,
                payload = null,
                source = null
            };
        }

        public static UserInfo MapToUserInfo(Parameter parameter) {
            return new UserInfo() {
                Name = parameter.firstName + " " + parameter.lastName,
                Email = parameter.email,
                PhoneNumber = parameter.phoneNumber,
                CompanyName = parameter.companyName
               
            };

        }

    }
}