using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace NoSQL.UI.Controllers
{
    public class AuthController : ControllerBase
    {
        public AuthController(ILogger<HomeController> logger) : base(logger)
        {
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult Logout()
        {
            throw new NotImplementedException();
        }
    }
}