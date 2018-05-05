using Chatbot.Business.Repository;
using Chatbot.Business.Repository.DAL;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chatbot.Business.Handlers {
    public class InformationManager {

        private static readonly ILog Logger = LogManager.GetLogger(typeof(InformationManager));
        private readonly DAL _dal;

        public InformationManager(IRepositoryInitialiser intialiser) {
            _dal = new DAL(intialiser);
        }



    }
}