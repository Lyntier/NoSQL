using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NoSQL.Models;

namespace NoSQL.UI.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Users()
        {
            List<User> users = new List<User>();

            users.Add(new User() { FirstName = "Piet", LastName = "Paulsma", EmailAddress = "piet.paulsma@gmail.com", Location = UserLocation.Amsterdam, Type = UserType.Employee, Password = "12345" });

            return View(users);
        }
    }
}
