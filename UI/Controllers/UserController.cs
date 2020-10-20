using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NoSQL.Models;
using NoSQL.Services;
using NoSQL.UI.ViewModels;

namespace NoSQL.UI.Controllers
{
    public class UserController : Controller
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpGet]
        public IActionResult Index()
        {

            // using (var client = GetHttpClient())
            // {
            //     var response = client.GetAsync("User");
            //     response.Wait();
            //
            //     var result = response.Result;
            //     if (result.IsSuccessStatusCode)
            //     {
            //         var readTask = result.Content.ReadAsAsync<List<User>>();
            //         users = readTask.Result;
            //     }
            // }

            var users = _userService.ListUsers();

            var uservm = new List<UserViewModel>();

            foreach (var user in users)
            {
                uservm.Add(new UserViewModel(user));
            }

            if (TempData["apiError"] != null)
            {
                ModelState.AddModelError("apiError", TempData["apiError"].ToString());
            }


            return View(uservm);
        }
        public IActionResult CreateUser()
        {
            UserViewModel view = new UserViewModel();

            return View(view);

        }
        [HttpPost]
        public IActionResult CreateUser(UserViewModel uservm)
        {
            User user = uservm;

            // using (var client = GetHttpClient())
            // {
            //     var response = client.PostAsJsonAsync("User", user);
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
            

            _userService.CreateUser(user);

            return RedirectToAction("Index");
        }
    }
}
