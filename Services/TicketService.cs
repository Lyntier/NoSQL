using System.Collections.Generic;
using NoSQL.DataAccess;
using NoSQL.Models;

namespace NoSQL.Services
{
    public class TicketService : ITicketService
    {
        private IRepository<Ticket> _ticketRepository;

        public TicketService(IRepository<Ticket> ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }
        public IEnumerable<Ticket> ListTickets()
        {
            return _ticketRepository.GetAll();
        }

        public void CreateTicket(Ticket ticket)
        {
            _ticketRepository.Add(ticket);
        }
    }
}