using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NoSQL.Models;
using NoSQL.UI.ViewModels;

namespace NoSQL.UI.Controllers
{
    public class UserTestController : ControllerBase
    {
        
        public UserTestController(ILogger<HomeController> logger) : base(logger)
        {
        }
        
        // GET
        public IActionResult Index()
        {
            User user = null;
            
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseApiUrl);
                var response = client.GetAsync("UserTest");
                response.Wait();

                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<User>();
                    user = readTask.Result;
                }
            }

            var uservm = new UserViewModel
            {
                Name = user != null ? user.Name : "Null"
            };
            
            
            return View(uservm);
        }

    }
}