using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatbot.Business.Repository {
    public interface IRepositoryInitialiser {
        IRequestRepository requestRepo { get; set; }
        IFlowRepository flowRepo { get; set; }
        IFlowDetailRepository flowDetailRepo { get; set; }
        ITicketRepository ticketRepo { get; set; }
    }
}
