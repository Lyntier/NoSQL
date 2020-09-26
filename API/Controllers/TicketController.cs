using Microsoft.AspNetCore.Mvc;
using NoSQL.Models;
using NoSQL.Services;

// ReSharper disable once InvalidXmlDocComment
/// <summary> Contains all controllers in the API. </summary>
namespace NoSQL.API.Controllers
{
    /// <summary> Takes care of API calls related to tickets. </summary>
    /// <seealso cref="Ticket"/>
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

        [HttpPost]
        public IActionResult Post(Ticket ticket)
        {
            _ticketService.CreateTicket(ticket);
            return Ok();
        }
    }
}