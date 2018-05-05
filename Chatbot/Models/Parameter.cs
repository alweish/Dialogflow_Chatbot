using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chatbot.Models {
    public class Parameter {
        [JsonProperty(PropertyName = "firstname")]
        public string firstName { get; set; }
        [JsonProperty(PropertyName = "lastname")]
        public string lastName { get; set; }
        [JsonProperty(PropertyName = "email")]
        public string email { get; set; }
        public string flow { get; set; }
        public string flowDetail { get; set; }
        public string extraInfo { get; set; }

        public string factuurNummer { get; set; }
        public string factuurDatum { get; set; }

        public string phoneNumber { get; set; }
        public string companyName { get; set; }
    }

}