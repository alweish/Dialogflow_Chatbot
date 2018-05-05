using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chatbot.Business.Repository {

    public class RepositoryInitialiser : IRepositoryInitialiser {
        public IRequestRepository requestRepo { get; set; }
        public IFlowRepository flowRepo { get; set; }
        public IFlowDetailRepository flowDetailRepo { get; set; }
        public ITicketRepository ticketRepo { get; set; }

        public RepositoryInitialiser() {
            requestRepo = new RequestRepository();
            flowRepo = new FlowRepository();
            flowDetailRepo = new FlowDetailRepository();
            ticketRepo = new TicketRepository();
        }

    }
}