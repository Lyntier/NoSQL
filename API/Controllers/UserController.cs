using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NoSQL.Services;
using NoSQL.Models;

namespace NoSQL.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public JsonResult Get()
        {
            return Json(_userService.ListUsers());
        }

        [HttpPost]
        public IActionResult Post(User user)
        {
            _userService.CreateUser(user);
            return Ok();
        }
    }
}
