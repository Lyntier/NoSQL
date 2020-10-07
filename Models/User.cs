using Newtonsoft.Json;
using NoSQL.Models.Util;

namespace NoSQL.Models
{
    [BsonCollection("users")]
    public class User : Entity
    {
        public string EmailAddress { get; set; }
        
        // Don't send password with each request.
        [JsonIgnore]
        public string Password { get; set; }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserType Type { get; set; }
        
        public string PhoneNumber { get; set; }
        
        public UserLocation Location { get; set; }
    }
}