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
        public Ticket()
        {
        }

        /// <summary> Creates a Ticket object and generates an ObjectID to attach to this ticket. </summary>
        public Ticket(string subject, string firstName, string lastName, DateTime date, int status)
            : this(ObjectId.GenerateNewId().ToString(), subject, firstName, lastName, date, status)
        {
            Subject = subject;
            FirstName = firstName;
            LastName = lastName;
            Date = date;
            Status = status;
        }

        /// <summary> Creates a Ticket object, using an already existing ObjectID. </summary>
        [JsonConstructor]
        public Ticket(string id, string subject, string firstName, string lastName, DateTime date, int status)
        {
            Id = id;
            Subject = subject;
            FirstName = firstName;
            LastName = lastName;
            Date = date;
            Status = status;
        }

        /// <summary> A short description of the incident that led to the creation of the ticket. </summary>
        public string Subject { get; set; }

        /// <summary> The first name of the person creating the ticket. </summary>
        public string FirstName { get; set; }

        /// <summary> The last name of the person creating the ticket. </summary>
        public string LastName { get; set; }

        /// <summary> The date at which the ticket was created. </summary>
        public DateTime Date { get; set; }

        /// <summary> The current status of the ticket. </summary>
        public int Status { get; set; }
    }
}