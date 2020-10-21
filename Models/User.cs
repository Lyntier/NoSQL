using AspNetCore.Identity.Mongo.Model;
using MongoDB.Bson.Serialization.Attributes;
using NoSQL.Models.Util;

namespace NoSQL.Models
{
    [BsonCollection("users")]
    [BsonIgnoreExtraElements]
    public class User : Entity
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserType Type { get; set; }
        
        public string PhoneNumber { get; set; }
        
        public UserLocation Location { get; set; }
    }
}