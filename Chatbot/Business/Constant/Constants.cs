using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chatbot.Business.Constant {
    public class Constants {
        public const string DBConnectionName = "JaneBot";

        public const string Flow_Invoice = "facturatie";
        public const string Flow_Other = "andere";
        public const string Flow_Infrastructure = "infrastructuur";

        public const string RegExEmail = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
          @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";

    }
}