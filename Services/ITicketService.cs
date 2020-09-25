using System.Collections.Generic;
using NoSQL.Models;

namespace NoSQL.Services
{
    public interface ITicketService
    {
        IEnumerable<Ticket> ListTickets();
        void CreateTicket(Ticket ticket);
    }
}