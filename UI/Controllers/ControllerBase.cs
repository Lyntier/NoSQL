using System;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace NoSQL.UI.Controllers
{
    /// <summary>
    /// Provides a barebones implementation for a controller in the application.
    /// </summary>
    public abstract class ControllerBase : Controller
    {
        /// <summary>
        /// The URL to which the application should send HTTP requests.
        /// </summary>
        protected const string BaseApiUrl = "https://localhost:3001/api/";
        
        /// <summary>
        /// Returns a HttpClient instance configured to use the API hosted at BaseApiUrl.
        /// </summary>
        protected HttpClient GetHttpClient() => new HttpClient {BaseAddress = new Uri(BaseApiUrl)};

        protected readonly ILogger<HomeController> Logger;

        protected ControllerBase(ILogger<HomeController> logger)
        {
            Logger = logger;
        }

    }
}