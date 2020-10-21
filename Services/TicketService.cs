using System;
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

        public IEnumerable<Ticket> FindTickets(Func<Ticket, bool> filter)
        {
            return _ticketRepository.Find(filter);
        }

        public IEnumerable<Ticket> FindTicketsByUser(User user)
        {
            return _ticketRepository.Find(ticket =>
                user.Id.Equals(ticket.User.Id)
            );
        }

        public IEnumerable<Ticket> FindTicketsByUser(string emailAddress)
        {
            return _ticketRepository.Find(ticket =>
                ticket.User.EmailAddress.Equals(emailAddress)
            );
        }
        
        public void RemoveTicket(ObjectId id)
        {
            var ticket = _ticketRepository.Find(u =>
            u.Id.Equals(id)).FirstOrDefault();
            _ticketRepository.Delete(ticket);
        }

        public void UpdateStatus(ObjectId id)
        {
            var ticket = _ticketRepository.Find(u => u.Id.Equals(id)).FirstOrDefault();
            ticket.IsOpen = false;
            _ticketRepository.Update(ticket);
        }
    }
}