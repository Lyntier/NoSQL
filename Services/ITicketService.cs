using System;
using System.Collections.Generic;
using MongoDB.Bson;
using NoSQL.Models;

// ReSharper disable once InvalidXmlDocComment
/// <summary> Contains all classes responsible for separate business logic events. </summary>
namespace NoSQL.Services
{
    /// <summary>
    /// Handles all application requests that have to do with tickets.
    /// </summary>
    public interface ITicketService
    {
        /// <summary>
        /// Returns a list of all tickets in the database.
        /// </summary>
        IEnumerable<Ticket> ListTickets();
        
        /// <summary>
        /// Adds the given ticket to the database.
        /// </summary>
        void CreateTicket(Ticket ticket);

        IEnumerable<Ticket> FindTickets(Func<Ticket, bool> filter);

        IEnumerable<Ticket> FindTicketsByUser(User user);

        IEnumerable<Ticket> FindTicketsByUser(string emailAddress);

        void RemoveTicket(ObjectId id);
    }
}