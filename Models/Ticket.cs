using System;
using NoSQL.Models.Util;

namespace NoSQL.Models
{
    [BsonCollection("tickets")]
    public class Ticket : Entity
    {
        public Ticket(string subject, string firstName, string lastName, DateTime date, int status)
        {
            Subject = subject;
            FirstName = firstName;
            LastName = lastName;
            Date = date;
            Status = status;
        }

        public string Subject { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Date { get; set; }
        public int Status { get; set; }
    }
}