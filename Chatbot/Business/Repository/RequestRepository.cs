using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Chatbot.Business.Constant;
using JaneBot;
using log4net;
using PetaPoco;

namespace Chatbot.Business.Repository {
    public class RequestRepository : IRequestRepository {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(RequestRepository));      

        public void Delete(Request entity) {
            throw new NotImplementedException();
        }

        public IList<Request> GetAll() {
            try {
                var db = new Database(Constant.Constants.DBConnectionName);
                return db.Fetch<Request>("SELECT * FROM Request");
            } catch (Exception e) {
                Logger.Error($"Error FetchAll Request");
                Logger.Error($"{e.Message}");
                Logger.Error($"{e.StackTrace}");
                return null;
            }
        }

        public Request GetByEmail(string email) {
            try {
                var db = new Database(Constant.Constants.DBConnectionName);
                return db.FirstOrDefault<Request>($"WHERE Email = @0", email);
            } catch (Exception e) {
                Logger.Error($"Error fetching Request");
                Logger.Error($"{e.Message}");
                Logger.Error($"{e.StackTrace}");
                return null;
            }
        }

        public Request GetById(int id) {
            try {
                var db = new Database(Constant.Constants.DBConnectionName);
                return db.FirstOrDefault<Request>($"WHERE Id = @0", id);
            } catch (Exception e) {
                Logger.Error($"Error fetching Request");
                Logger.Error($"{e.Message}");
                Logger.Error($"{e.StackTrace}");
                return null;
            }
        }

        public int Insert(Request entity) {
            try {
                var db = new Database(Constant.Constants.DBConnectionName);
                return (int)db.Insert(entity);
            } catch (Exception e) {
                Logger.Error("Error inserting Request");
                Logger.Error($"{e.Message}");
                Logger.Error($"{e.StackTrace}");
                return -1;
            }
        }

        public void Update(Request entity) {
            try {
                var db = new Database(Constant.Constants.DBConnectionName);
                db.Update(entity);
            } catch (Exception e) {
                Logger.Error($"Error updating Request data");
                Logger.Error($"{e.Message}");
                Logger.Error($"{e.StackTrace}");
            }
        }
    }
}