using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NoSQL.Models;
using NoSQL.Services;
using NoSQL.UI.ViewModels;

namespace NoSQL.UI.Controllers
{
    public class HomeController : Controller
    {
        private ITicketService _ticketService;

        public HomeController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        public IActionResult Index()
        {
            var identity = (ClaimsIdentity) User.Identity;

            // Checks if user is a service desk employee or regular employee.
            var isServiceDeskEmployee = identity.HasClaim(claim => claim.Value.Equals("ServiceDeskEmployee"));

            List<Ticket> tickets;

            if (isServiceDeskEmployee)
            {
                tickets = _ticketService.FindTickets(ticket =>
                        ticket.Priority == TicketPriority.High)
                    .ToList();
            }
            else
            {
                tickets = _ticketService.FindTicketsByUser(identity.FindFirst(ClaimTypes.Name).Value)
                    .ToList();
            }

            
            var ticketvm = new List<TicketViewModel>();
            foreach (var ticket in tickets)
            {
                ticketvm.Add(new TicketViewModel(ticket));
            }

            return View(isServiceDeskEmployee
                    ? "DashboardServiceDeskEmployee"
                    : "DashboardEmployee",
                ticketvm);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}