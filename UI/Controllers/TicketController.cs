using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
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
        private IUserService _userService;
        
        public TicketController(ITicketService ticketService, IUserService userService)
        {
            _ticketService = ticketService;
            _userService = userService;
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
            view.Deadline = System.DateTime.Now;
            return View(view);
        }

        /// <summary>
        /// Inserts a new ticket into the database with values set according to the values in the Html form.
        /// </summary>
        [HttpPost]
        public IActionResult CreateTicket(TicketViewModel ticketvm)
        {
            var identity = (ClaimsIdentity)User.Identity;

            var emailAddress = identity.FindFirst(ClaimTypes.Name).Value;

            var user = _userService.GetByEmail(emailAddress);

            Ticket ticket = ticketvm;
            ticket.User = user;

            switch (ticket.Priority) {
                case TicketPriority.Low:
                    ticket.Deadline = DateTime.Now.AddDays(1);
                    break;
                case TicketPriority.Normal:
                    ticket.Deadline = DateTime.Now.AddHours(7);
                    break;
                case TicketPriority.High:
                    ticket.Deadline = DateTime.Now.AddHours(1);
                    break;
                }
            ticket.Deadline = ticket.Deadline.AddHours(2);
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

        public IActionResult RemoveTicket(string id)
        {
            ObjectId Id = new ObjectId(id);
            _ticketService.RemoveTicket(Id);
            TempData["removeTicket"] = "Successfully deleted ticket.";
            return RedirectToAction("Index");
        }
    }
}