using System.Collections.Generic;
using NoSQL.DataAccess;
using NoSQL.Models;

namespace NoSQL.Services
{
    public class TicketService : ITicketService
    {
        private IRepository<Ticket> ticketRepository;

        public TicketService(IRepository<Ticket> ticketRepository)
        {
            this.ticketRepository = ticketRepository;
        }
        public IEnumerable<Ticket> ListTickets()
        {
            return ticketRepository.GetAll();
        }

        public void CreateTicket(Ticket ticket)
        {
            ticketRepository.Add(ticket);
        }
    }
}