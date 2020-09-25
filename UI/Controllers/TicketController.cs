using System;
using System.Collections.Generic;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using NoSQL.Models;
using NoSQL.UI.ViewModels;

namespace NoSQL.UI.Controllers
{
    public class TicketController : ControllerBase
    {
        public TicketController(ILogger<HomeController> logger) : base(logger)
        {
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Ticket> tickets = new List<Ticket>();

            using (var client = GetHttpClient())
            {
                var response = client.GetAsync("Ticket");
                response.Wait();

                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<Ticket>>();
                    tickets = readTask.Result;
                }
            }

            var ticketvm = new List<TicketViewModel>();
            foreach (var ticket in tickets)
            {
                ticketvm.Add(new TicketViewModel(ticket));
            }


            return View(ticketvm);
        }

        [HttpPut]
        public IActionResult CreateTicket(TicketViewModel ticketvm)
        {
            Ticket ticket = new Ticket(ticketvm.Subject, ticketvm.FirstName, ticketvm.LastName, ticketvm.Date,
                ticketvm.Status)
            {
                Id = new ObjectId(ticketvm.Id)
            };

            using (var client = GetHttpClient())
            {
                var response = client.PutAsJsonAsync<Ticket>("Ticket", ticket);
                response.Wait();

                var result = response.Result;
                if (!result.IsSuccessStatusCode)
                {
                    ModelState.AddModelError("apiError", "Something failed.");
                }
            }

            return View("Index");
        }
    }
}