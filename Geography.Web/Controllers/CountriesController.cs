using Geography.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Geography.Web.Controllers
{
    /// <summary>
    /// Serves pages that list countries and their related geographic information.
    /// </summary>
    public class CountriesController(ICountriesService service) : Controller
    {
        /// <summary>Retrieves all countries and passes them to the Countries index view.</summary>
        [HttpGet]
        public IActionResult Index()
            => View(service.GetAllCountries());
    }
}