using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Logging;
using NoSQL.Models;
using NoSQL.Services;
using WebMatrix.WebData;

namespace NoSQL.UI.Controllers
{
    public class LoginController : Controller
    {
        ILoginService _loginService;

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string emailAddress, string password)
        {
            var success = _loginService.Login(emailAddress, password, out User user);

            if (!success)
            {
                TempData["authError"] = "Could not authenticate with given username and password, please try again.";
                return RedirectToAction("Login", HttpMethod.Get);
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, emailAddress),
                // TODO Add role
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

            return RedirectToAction("Index", "Home", HttpMethod.Get);
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Login", HttpMethod.Post);
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassword(string UserName)
        {
            if (ModelState.IsValid)
            {

                if (WebSecurity.UserExists(UserName))
                {
                    string To = UserName, UserID, Password, SMTPPort, Host;
                    string token = WebSecurity.GeneratePasswordResetToken(UserName);
                    if (token == null)
                    {
                        // If user does not exist or is not confirmed.  

                        return View("Index");

                    }
                    else
                    {
                        //Create URL with above token  

                        var lnkHref = "<a href='" + Url.Action("ResetPassword", "Account", new { email = UserName, code = token }, "http") + "'>Reset Password</a>";


                        //HTML Template for Send email  

                        string subject = "Your changed password";

                        string body = "<b>Please find the Password Reset Link. </b><br/>" + lnkHref;


                        //Get and set the AppSettings using configuration manager.  

                        EmailManager.AppSettings(out UserID, out Password, out SMTPPort, out Host);


                        //Call send email methods.  

                        EmailManager.SendEmail(UserID, subject, body, To, UserID, Password, SMTPPort, Host);

                    }

                }

            }
            return View();
        }
        public ActionResult ResetPassword(string code, string email)
        {
            ResetPassword model = new ResetPassword();
            model.ReturnToken = code;
            return View(model);
        }

        [HttpPost]
        public ActionResult ResetPassword(ResetPassword model)
        {
            if (ModelState.IsValid)
            {
                bool resetResponse = WebSecurity.ResetPassword(model.ReturnToken, model.Password);
                if (resetResponse)
                {
                    ViewBag.Message = "Successfully Changed";
                }
                else
                {
                    ViewBag.Message = "Something went horribly wrong!";
                }
            }
            return View(model);
        }

    }
}
