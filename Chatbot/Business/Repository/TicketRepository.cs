using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JaneBot;
using log4net;
using PetaPoco;

namespace Chatbot.Business.Repository {
    public class TicketRepository : ITicketRepository {

        private static readonly ILog Logger = LogManager.GetLogger(typeof(FlowRepository));
        public void Delete(Ticket entity) {
            throw new NotImplementedException();
        }

        public IList<Ticket> GetAll() {
            try {
                var db = new Database(Constant.Constants.DBConnectionName);
                return db.Fetch<Ticket>("SELECT * FROM Ticket");
            } catch (Exception e) {
                Logger.Error($"Error FetchAll Ticket");
                Logger.Error($"{e.Message}");
                Logger.Error($"{e.StackTrace}");
                return null;
            }
        }

        public Ticket GetById(int id) {
            try {
                var db = new Database(Constant.Constants.DBConnectionName);
                return db.FirstOrDefault<Ticket>($"WHERE Id = @0", id);
            } catch (Exception e) {
                Logger.Error($"Error fetching Ticket");
                Logger.Error($"{e.Message}");
                Logger.Error($"{e.StackTrace}");
                return null;
            }
        }

        public Ticket GetByUserId(int id) {
            try {
                var db = new Database(Constant.Constants.DBConnectionName);
                return db.FirstOrDefault<Ticket>($"WHERE UserId = @0", id);
            } catch (Exception e) {
                Logger.Error($"Error fetching Ticket");
                Logger.Error($"{e.Message}");
                Logger.Error($"{e.StackTrace}");
                return null;
            }
        }

        public int Insert(Ticket entity) {
            try {
                var db = new Database(Constant.Constants.DBConnectionName);
                return (int)db.Insert(entity);
            } catch (Exception e) {
                Logger.Error("Error inserting Ticket");
                Logger.Error($"{e.Message}");
                Logger.Error($"{e.StackTrace}");
                return -1;
            }
        }

        public void Update(Ticket entity) {
            try {
                var db = new Database(Constant.Constants.DBConnectionName);
                db.Update(entity);
            } catch (Exception e) {
                Logger.Error($"Error updating Ticket data");
                Logger.Error($"{e.Message}");
                Logger.Error($"{e.StackTrace}");
            }
        }
    }
}