using System;
using System.ComponentModel.DataAnnotations;
using NoSQL.Models;

namespace NoSQL.UI.ViewModels
{
    /// <summary>
    /// Allows the conversion of the Ticket model to a user-friendly format.
    /// </summary>
    public class TicketViewModel
    {
        public TicketViewModel()
        {
        }

        public TicketViewModel(Ticket ticket)
            : this(ticket.Id, ticket.Subject, ticket.FirstName, ticket.LastName, ticket.Date, ticket.Status)
        {
        }

        public TicketViewModel(string id, string subject, string firstName, string lastName, DateTime date, int status)
        {
            Id = id;
            Subject = subject;
            FirstName = firstName;
            LastName = lastName;
            Date = date;
            Status = status;
        }

        [ScaffoldColumn(false)]
        public string Id { get; set; }
        public string Subject { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Date { get; set; }
        public int Status { get; set; }
    }
}