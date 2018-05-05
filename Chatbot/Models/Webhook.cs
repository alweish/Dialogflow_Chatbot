using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chatbot.Models {
    public class WebhookRequest {
        public string responseId { get; set; }
        public string session { get; set; }
        public QueryResult queryResult { get; set; }
        public object originalDetectIntentRequest { get; set; }
    }

    public class Context {
        public string name { get; set; }
        public object parameters { get; set; }
        public int lifespanCount { get; set; }
    }

    public class QueryResult {
        public string queryText { get; set; }
        public string action { get; set; }
        public Dictionary<string, string> parameters { get; set; }
        public bool allRequiredParamsPresent { get; set; }
        public string fulfillmentText { get; set; }
        public object fulfillmentMessages { get; set; }
        public List<Context> outputContexts { get; set; }
        public object intent { get; set; }
        public int intentDetectionConfidence { get; set; }
        public object diagnosticInfo { get; set; }
        public string languageCode { get; set; }
    }
    public class WebhookStatus {
        public int code { get; set; }
        public string message { get; set; }
    }

    public class WebhookResponse {
        public string fulfillmentText { get; set; }
        public object fulfillmentMessages { get; set; }
        public string source { get; set; }
        public object payload { get; set; }
        public List<Context> outputContexts { get; set; }
        public object followupEventInput { get; set; }
    }

    public class FulFillmentMessage {
        public string title { get; set; }
        public string subtitle { get; set; }
        public string imageUri { get; set; }
        public List<Button> buttons { get; set; }
    }

    public class Button {
        public string text { get; set; }
        public string postback { get; set; }
    }
    
}