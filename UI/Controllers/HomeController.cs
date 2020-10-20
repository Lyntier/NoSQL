using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NoSQL.UI.ViewModels;

namespace NoSQL.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // Check if user is service desk employee or not
            if (((ClaimsIdentity) User.Identity)
                .HasClaim(x => x.Value == "ServiceDeskEmployee"))
            {
                return View("DashboardServiceDeskEmployee");
            }
            return View("DashboardEmployee");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
