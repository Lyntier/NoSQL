using System.Net;
using Microsoft.AspNetCore.Mvc;
using NoSQL.Models;
using NoSQL.Services;

namespace NoSQL.API.Controllers
{
    [ApiController]
    public class AuthController : Controller
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public JsonResult Login(string username, string password)
        {
            var success = _authService.Login(username, password, out User user);

            if (success)
            {
                return Json((user));
            }

            // Couldn't login with given username and password.
            Response.StatusCode = (int) HttpStatusCode.Forbidden;
            return Json((username, password));
        }
    }
}