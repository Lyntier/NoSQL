using System.Net;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver.Core.Authentication;
using NoSQL.Models;
using NoSQL.Services;

namespace NoSQL.API.Controllers
{
    public class AuthController : Controller
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        
        [HttpPost]
        public IActionResult Login(string emailAddress, string password)
        {
            User user = _authService.Login(emailAddress, password);
            if(user)
            {
                // User found. Return user object for session.
                return Ok(user);
            }
            
            // Couldn't find user with given email and password in DB.
            // Either user isn't registered yet, or email/password combination is incorrect.
            return Unauthorized(emailAddress);
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            bool registered = _authService.Register(user);
            if (registered)
            {
                return Ok(user);
            }
            
            // Couldn't register current user.
            return BadRequest(user);
        }
    }
}