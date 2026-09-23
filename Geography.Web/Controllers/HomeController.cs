using Geography.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Geography.Web.Controllers
{
    /// <summary>
    /// Serves the home page and the shared application error page.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>Displays the application's landing page.</summary>
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>Displays a non-cacheable error page with an optional request identifier.</summary>
        [HttpGet]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}