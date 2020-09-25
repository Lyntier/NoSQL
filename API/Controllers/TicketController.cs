using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using NoSQL.Models;
using NoSQL.Services;

namespace NoSQL.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : Controller
    {
        private ITicketService _ticketService;
        
        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }
        
        [HttpGet]
        public JsonResult Get()
        {
            return Json(_ticketService.ListTickets());
        }

        [HttpPut]
        public IActionResult Put(Ticket ticket)
        {
            _ticketService.CreateTicket(ticket);
            return Ok();
        }
    }
}