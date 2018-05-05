using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chatbot.Models {
    public class Response {
        public Parameter Parameter { get; set; }
        public bool TicketSent { get; set; }
        public string Message { get; set; }
    }
}