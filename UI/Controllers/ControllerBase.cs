using System;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace NoSQL.UI.Controllers
{
    public abstract class ControllerBase : Controller
    {
        protected const string BaseApiUrl = "https://localhost:3001/api/";

        protected readonly ILogger<HomeController> Logger;

        protected ControllerBase(ILogger<HomeController> logger)
        {
            Logger = logger;
        }

        protected HttpClient GetHttpClient() => new HttpClient {BaseAddress = new Uri(BaseApiUrl)};
    }
}