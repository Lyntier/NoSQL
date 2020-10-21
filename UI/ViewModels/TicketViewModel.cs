using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
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
        {
            Id = ticket.Id;
            DateReported = ticket.DateReported.Year == 1 ? DateTime.Now : ticket.DateReported;
            Subject = ticket.Subject;
            IncidentType = ticket.IncidentType;
            User = new UserViewModel(ticket.User);
            Priority = ticket.Priority;
            Deadline = ticket.Deadline;
            Description = ticket.Description;
            IsOpen = ticket.IsOpen;
        }

        [ScaffoldColumn(false)]
        public ObjectId Id { get; set; }
        
        /// <summary> The date at which the ticket was created. </summary>
        public DateTime DateReported { get; set; }

        /// <summary> A short description of the incident that led to the creation of the ticket. </summary>
        public string Subject { get; set; }

        /// <summary> The type of incident the ticket describes. </summary>
        public IncidentType IncidentType { get; set; }
        
        /// <summary> The user that reported this incident. </summary>
        public UserViewModel User { get; set; }
        
        /// <summary> The priority for this ticket, indicating its importance. </summary>
        public TicketPriority Priority { get; set; }

        /// <summary> The date at which the incident should be handled. </summary>
        [Display(Name = "Deadline")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Deadline { get; set; }

        /// <summary> A longer description of the ticket. </summary>
        public string Description { get; set; }

        public bool IsOpen { get; set; }
        
        public static implicit operator Ticket(TicketViewModel ticketvm)
        {
            var isIdNull = ticketvm.Id == null;
            return new Ticket
            {
                // If no date was assigned to the ticket, a new date object will be created and start at year 1.
                // Tickets from year 1 are of course not desired in the application.
                DateReported = ticketvm.DateReported.Year == 1 ? DateTime.Now : ticketvm.DateReported,
                Deadline = ticketvm.Deadline,
                Description = ticketvm.Description,
                Id = isIdNull ? ObjectId.GenerateNewId() : ticketvm.Id,
                IncidentType = ticketvm.IncidentType,
                Priority = ticketvm.Priority,
                Subject = ticketvm.Subject,
                User = ticketvm.User,
                IsOpen = ticketvm.IsOpen
            };
        }
    }
}