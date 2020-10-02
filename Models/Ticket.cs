using System;
using MongoDB.Bson;
using Newtonsoft.Json;
using NoSQL.Models.Util;

namespace NoSQL.Models
{
    /// <summary>
    /// Represents a ticket within the application.
    /// Tickets are collections of information on an incident.
    /// </summary>
    [BsonCollection("tickets")]
    public class Ticket : Entity
    {
        /// <summary> The date at which the ticket was created. </summary>
        public DateTime DateReported { get; set; }

        /// <summary> A short description of the incident that led to the creation of the ticket. </summary>
        public string Subject { get; set; }

        /// <summary> The type of incident the ticket describes. </summary>
        public IncidentType IncidentType { get; set; }
        
        /// <summary> The user that reported this incident. </summary>
        public User User { get; set; }
        
        /// <summary> The priority for this ticket, indicating its importance. </summary>
        public TicketPriority Priority { get; set; }

        /// <summary> The date at which the incident should be handled. </summary>
        public DateTime Deadline { get; set; }
        
        /// <summary> A longer description of the ticket. </summary>
        public string Description { get; set; }
    }
}