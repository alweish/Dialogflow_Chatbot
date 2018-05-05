using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JaneBot;
using log4net;
using PetaPoco;

namespace Chatbot.Business.Repository {
    public class FlowDetailRepository : IFlowDetailRepository {

        private static readonly ILog Logger = LogManager.GetLogger(typeof(FlowRepository));
        public void Delete(FlowDetail entity) {
            throw new NotImplementedException();
        }

        public IList<FlowDetail> GetAll() {
            try {
                var db = new Database(Constant.Constants.DBConnectionName);
                return db.Fetch<FlowDetail>("SELECT * FROM FlowDetail");
            } catch (Exception e) {
                Logger.Error($"Error FetchAll FlowDetail");
                Logger.Error($"{e.Message}");
                Logger.Error($"{e.StackTrace}");
                return null;
            }
        }

        public FlowDetail GetById(int id) {
            try {
                var db = new Database(Constant.Constants.DBConnectionName);
                return db.FirstOrDefault<FlowDetail>($"WHERE Id = @0", id);
            } catch (Exception e) {
                Logger.Error($"Error fetching FlowDetail");
                Logger.Error($"{e.Message}");
                Logger.Error($"{e.StackTrace}");
                return null;
            }
        }

        public FlowDetail GetByName(string name) {
            try {
                var db = new Database(Constant.Constants.DBConnectionName);
                return db.FirstOrDefault<FlowDetail>($"WHERE Name = @0", name);
            } catch (Exception e) {
                Logger.Error($"Error fetching FlowDetail");
                Logger.Error($"{e.Message}");
                Logger.Error($"{e.StackTrace}");
                return null;
            }
        }

        public int Insert(FlowDetail entity) {
            throw new NotImplementedException();
        }

        public void Update(FlowDetail entity) {
            throw new NotImplementedException();
        }
    }
}