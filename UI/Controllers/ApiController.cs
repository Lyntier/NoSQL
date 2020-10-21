using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using NoSQL.Services;

namespace NoSQL.UI.Controllers
{
    [Route("/api")]
    [ApiController]
    public class ApiController : Controller
    {
        private IUserService _userService;
        private ILoginService _loginService;
        private ITicketService _ticketService;

        public ApiController(IUserService userService, ILoginService loginService, ITicketService ticketService)
        {
            _userService = userService;
            _loginService = loginService;
            _ticketService = ticketService;
        }
        
        [Route("/api/users")]
        public JsonResult GetUsers()
        {
            return Json(_userService.ListUsers());
        }

        [Route("/api/tickets/delete/{id}")]
        public JsonResult DeleteTicket(string id)
        {
            var objId = new ObjectId(id);
            _ticketService.RemoveTicket(objId);
            return Json(Ok());
        }
        
        
    }
}