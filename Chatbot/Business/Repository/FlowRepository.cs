using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JaneBot;
using log4net;
using PetaPoco;

namespace Chatbot.Business.Repository {
    public class FlowRepository : IFlowRepository {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(FlowRepository));

        public void Delete(Flow entity) {
            throw new NotImplementedException();
        }

        public IList<Flow> GetAll() {
            try {
                var db = new Database(Constant.Constants.DBConnectionName);
                return db.Fetch<Flow>("SELECT * FROM Flow");
            } catch (Exception e) {
                Logger.Error($"Error FetchAll Flow");
                Logger.Error($"{e.Message}");
                Logger.Error($"{e.StackTrace}");
                return null;
            }
        }

        public Flow GetById(int id) {
            try {
                var db = new Database(Constant.Constants.DBConnectionName);
                return db.FirstOrDefault<Flow>($"WHERE Id = @0", id);
            } catch (Exception e) {
                Logger.Error($"Error fetching Flow");
                Logger.Error($"{e.Message}");
                Logger.Error($"{e.StackTrace}");
                return null;
            }
        }

        public Flow GetByName(string name) {
            try {
                var db = new Database(Constant.Constants.DBConnectionName);
                return db.FirstOrDefault<Flow>($"WHERE Name = @0", name);
            } catch (Exception e) {
                Logger.Error($"Error fetching Flow");
                Logger.Error($"{e.Message}");
                Logger.Error($"{e.StackTrace}");
                return null;
            }
        }

        public int Insert(Flow entity) {
            throw new NotImplementedException();
        }

        public void Update(Flow entity) {
            throw new NotImplementedException();
        }
    }
}