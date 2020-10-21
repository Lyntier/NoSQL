using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using NoSQL.DataAccess;
using NoSQL.Models;

namespace NoSQL.Services
{
    /// <inheritdoc cref="ITicketService"/>
    public class TicketService : ITicketService
    {
        private IRepository<Ticket> _ticketRepository;

        public TicketService(IRepository<Ticket> ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }
        
        /// <inheritdoc cref="ITicketService"/>
        public IEnumerable<Ticket> ListTickets()
        {
            return _ticketRepository.GetAll();
        }

        
        /// <inheritdoc cref="ITicketService"/>
        public void CreateTicket(Ticket ticket)
        {
            _ticketRepository.Add(ticket);
        }
        public void RemoveTicket(ObjectId id)
        {
            var ticket = _ticketRepository.Find(u =>
            u.Id.Equals(id)).FirstOrDefault();
            _ticketRepository.Delete(ticket);
        }
    }
}