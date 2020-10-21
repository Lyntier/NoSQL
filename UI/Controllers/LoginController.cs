using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using NoSQL.Models;
using NoSQL.Services;
using NoSQL.UI.ViewModels;
using WebMatrix.WebData;

namespace NoSQL.UI.Controllers
{
    public class LoginController : Controller
    {
        ILoginService _loginService;

        private IUserService _userService;
        private IEmailManager _emailManager;
        
        public LoginController(ILoginService loginService, IUserService userService,IEmailManager emailManager)
        {
            _loginService = loginService;
            _userService = userService;
            _emailManager = emailManager;
        }

        [AllowAnonymous]
        public IActionResult AddTestUser()
        {
            User user = new User
            {
                EmailAddress = "test@test.com",
                Password = "123456",
                FirstName = "Nick",
                LastName  = "Versteeg",
                Location = UserLocation.Haarlem,
                PhoneNumber = "+31651948803",
                Type = UserType.ServiceDeskEmployee
            };

            _userService.CreateUser(user);
            if (user.Id == null)
            {
                TempData["registerError"] = "Registration failed!";
            }
            else
            {
                TempData["registerError"] = "Registration successful!";
            }

            return RedirectToAction("Login");

        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return RedirectToAction("Login");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(UserViewModel uservm)
        {
            var success = _loginService.Login(uservm.EmailAddress, uservm.Password, out User user);

            if (!success)
            {
                TempData["authError"] = "Could not authenticate with given username and password, please try again.";
                return RedirectToAction("Login");
            }

            // Two types of users: ServiceDeskEmployees and Employees.
            var userRole = user.Type == UserType.ServiceDeskEmployee ? "ServiceDeskEmployee" : "Employee";
            
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.EmailAddress),
                new Claim(ClaimTypes.Role, userRole)
            };
            
            var claimsIdentity = new ClaimsIdentity(
                claims,
                CookieAuthenticationDefaults.AuthenticationScheme);
            
            var authProperties = new AuthenticationProperties
            {
                // TODO Configure authentication properties like expiry time
            };

            HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

            return RedirectToAction("Index", "Home");
        }
        
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Register(UserViewModel uservm)
        {
            User user = uservm;
            _userService.CreateUser(user);
            if (user.Id == null)
            {
                TempData["registerError"] = "Registration failed!";
            }
            else
            {
                TempData["registerError"] = "Registration successful!";
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Login", HttpMethod.Post);
        }

        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult ForgotPassword(ForgotPasswordViewModel model)
        {
            var UserName = model.Email;
            if (ModelState.IsValid)
            {
                var user = _userService.GetByEmail(UserName);
                if (user)
                {
                    string To = UserName, UserID, Password, SMTPPort, Host;
                    string token = ObjectId.GenerateNewId().ToString();
                    if (token == null)
                    {
                        // If user does not exist or is not confirmed.  

                        return View("Login");

                    }
                    else
                    {
                        _loginService.SaveToken(token,UserName);
                        //Create URL with above token  

                        var lnkHref = "<a href='" + Url.Action("ResetPassword", "Login", new {code = token }, "https") + "'>Reset Password</a>";


                        //HTML Template for Send email  

                        string subject = "Your changed password";

                        string body = "<b>Please find the Password Reset Link. </b><br/>" + lnkHref;


                        //Get and set the AppSettings using configuration manager.  

                       _emailManager.AppSettings(out UserID, out Password, out SMTPPort, out Host);


                        //Call send email methods.  

                        _emailManager.SendEmail(UserID, subject, body, To, UserID, Password, SMTPPort, Host);

                    }

                }

            }
            return View();
        }
        
        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            ResetPasswordViewModel model = new ResetPasswordViewModel();
            model.Token = code;
            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.NewPassword.Equals(model.ConfirmPassword))
                {
                    _loginService.ResetPassword(model.Token, model.NewPassword);
                }
            }
            return RedirectToAction("Index","Home");
        }

    }
}
