using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NoSQL.Models;
using NoSQL.Services;
using NoSQL.UI.ViewModels;

namespace NoSQL.UI.Controllers
{
    /// <summary>
    /// Handles all requests fired by the web application with regards to Tickets.
    /// </summary>
    public class TicketController : Controller
    {
        private ITicketService _ticketService;
        
        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        /// <summary>
        /// Shows all tickets in the database and allows the addition of tickets.
        /// </summary>
        [HttpGet]
        public IActionResult Index()
        {
            // List<Ticket> tickets = new List<Ticket>();

            // using (var client = GetHttpClient())
            // {
            //     var response = client.GetAsync("Ticket");
            //     response.Wait();
            //
            //     var result = response.Result;
            //     if (result.IsSuccessStatusCode)
            //     {
            //         var readTask = result.Content.ReadAsAsync<List<Ticket>>();
            //         tickets = readTask.Result;
            //     }
            // }

            var tickets = _ticketService.ListTickets();

            var sortedTicketList = tickets.OrderByDescending(X => (int)(X.Priority)).ToList();

            var ticketvm = new List<TicketViewModel>();
            foreach (var ticket in sortedTicketList)
            {
                ticketvm.Add(new TicketViewModel(ticket));
            }

            if (TempData["apiError"] != null)
            {
                ModelState.AddModelError("apiError", TempData["apiError"].ToString());
            }


            return View(ticketvm);
        }
        public IActionResult CreateTicket()
        {
            TicketViewModel view = new TicketViewModel();
            return View(view);
        }

        /// <summary>
        /// Inserts a new ticket into the database with values set according to the values in the Html form.
        /// </summary>
        [HttpPost]
        public IActionResult CreateTicket(TicketViewModel ticketvm)
        {
            Ticket ticket = ticketvm;

            // using (var client = GetHttpClient())
            // {
            //     var response = client.PostAsJsonAsync("Ticket", ticket);
            //     response.Wait();
            //
            //     var result = response.Result;
            //     if (!result.IsSuccessStatusCode)
            //     {
            //         TempData["apiError"] = result.Content.ReadAsStringAsync().Result;
            //     }
            //     else
            //     {
            //         TempData["apiError"] = null;
            //     }
            // }

            _ticketService.CreateTicket(ticket);
            
            return RedirectToAction("Index");
        }
    }
}