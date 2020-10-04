using Microsoft.AspNetCore.Mvc;

namespace NoSQL.UI.Controllers
{
    public class AuthController : Controller
    {
        /// <summary> The login page of the application. </summary>
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
    }
}