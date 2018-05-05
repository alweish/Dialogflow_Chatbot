using JaneBot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chatbot.Business.Repository {
    public interface IRequestRepository {
        int Insert(Request entity);
        void Delete(Request entity);
        void Update(Request entity);
        IList<Request> GetAll();
        Request GetById(int id);
        Request GetByEmail(string email);
    }

    public interface IFlowRepository {
        int Insert(Flow entity);
        void Delete(Flow entity);
        void Update(Flow entity);
        IList<Flow> GetAll();
        Flow GetById(int id);
        Flow GetByName(string name);
    }
    public interface IFlowDetailRepository {
        int Insert(FlowDetail entity);
        void Delete(FlowDetail entity);
        void Update(FlowDetail entity);
        IList<FlowDetail> GetAll();
        FlowDetail GetById(int id);
        FlowDetail GetByName(string name);
    }
    public interface ITicketRepository {
        int Insert(Ticket entity);
        void Delete(Ticket entity);
        void Update(Ticket entity);
        IList<Ticket> GetAll();
        Ticket GetById(int id);
        Ticket GetByUserId(int id);
    }
}