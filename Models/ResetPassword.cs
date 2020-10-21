using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using NoSQL.Models.Util;
using MongoDB.Bson.Serialization.Attributes;

namespace NoSQL.Models
{
    [BsonCollection("resetpassword")]
    [BsonIgnoreExtraElements]
    public class ResetPassword : Entity
    {
        public string ReturnToken { get; set; }
        public string Email { get; set; }
    }
}
