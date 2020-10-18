using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace NoSQL.Models
{
    public class ResetPassword
    {
        public string ReturnToken { get; set; }
        [ScaffoldColumn(false)] public string Password { get; set; }
    }
}
