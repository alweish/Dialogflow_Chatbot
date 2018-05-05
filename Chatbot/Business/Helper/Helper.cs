using Chatbot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chatbot.Business.Helper {
    public static class Helper {
        public static Parameter GetObject(Dictionary<string, string> dictionary) {
            Type type = typeof(Parameter);
            var obj = Activator.CreateInstance(type);

            foreach (var keyvalue in dictionary) {
                if (!keyvalue.Key.Contains(".")) {
                    type.GetProperty(keyvalue.Key).SetValue(obj, keyvalue.Value);
                }
            }
            return (Parameter)obj;
        }
    }
}