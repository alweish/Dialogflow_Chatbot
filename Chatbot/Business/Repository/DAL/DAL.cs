using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JaneBot;
using log4net;

namespace Chatbot.Business.Repository.DAL {
    public class DAL {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(DAL));
        private IRepositoryInitialiser repositoryInitialiser;

        public DAL(IRepositoryInitialiser repoInitialiser) {
            repositoryInitialiser = repoInitialiser;
        }

        #region Request
        public IList<Request> GetAllRequests() {
            return repositoryInitialiser.requestRepo.GetAll();
        }
        public Request GetRequestById(int id) {
            return repositoryInitialiser.requestRepo.GetById(id);
        }
        public int CreateRequest(Request model) {
            return repositoryInitialiser.requestRepo.Insert(model);
        }
        public Request GetRequestByUserName(string lastname, string firstname) {
            return repositoryInitialiser.requestRepo.GetByName(lastname, firstname);
        }
        public void UpdateRequest(Request model) {
            repositoryInitialiser.requestRepo.Update(model);
        }
        #endregion

        #region Flow
        public IList<Flow> GetAllFlows() {
            return repositoryInitialiser.flowRepo.GetAll();
        }
        public Flow GetFlowById(int id) {
            return repositoryInitialiser.flowRepo.GetById(id);
        }
        public Flow GetFlowByName(string name) {
            return repositoryInitialiser.flowRepo.GetByName(name);
        }
        #endregion

        #region FlowDetail
        public IList<FlowDetail> GetAllFlowDetails() {
            return repositoryInitialiser.flowDetailRepo.GetAll();
        }
        public FlowDetail GetFlowDetailById(int id) {
            return repositoryInitialiser.flowDetailRepo.GetById(id);
        }
        public FlowDetail GetFlowDetailByName(string name) {
            return repositoryInitialiser.flowDetailRepo.GetByName(name);
        }
        #endregion

        #region Ticket
        public IList<Ticket> GetAllTickets() {
            return repositoryInitialiser.ticketRepo.GetAll();
        }
        public Ticket GetTicketById(int id) {
            return repositoryInitialiser.ticketRepo.GetById(id);
        }
        public Ticket GetTicketByUserId(int id) {
            return repositoryInitialiser.ticketRepo.GetByUserId(id);
        }
        public int CreateTicket(Ticket model) {
            return repositoryInitialiser.ticketRepo.Insert(model);
        }        
        public void UpdateTicket(Ticket model) {
            repositoryInitialiser.ticketRepo.Update(model);
        }
        #endregion
    }
}