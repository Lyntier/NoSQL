using Microsoft.AspNetCore.Mvc;
using NoSQL.Models;

namespace NoSQL.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserTestController : Controller
    {
        [HttpGet]
        public JsonResult Get()
        {
            var user = new User();
            user.Name = "Nick";
            return Json(user);
        }
    }
}