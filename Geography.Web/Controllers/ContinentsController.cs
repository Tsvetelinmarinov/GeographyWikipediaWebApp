using Geography.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Geography.Web.Controllers
{
    /// <summary>
    /// Serves continent listings and the country listing for an individual continent.
    /// </summary>
    public class ContinentsController(IContinentsService service) : Controller
    {
        /// <summary>Retrieves all continents and passes them to the index view.</summary>
        [HttpGet]
        public IActionResult Index()
            => View(service.GetAllContinents());

        /// <summary>Retrieves the countries that belong to the continent identified by the route/query code.</summary>
        [HttpGet]
        public IActionResult CountriesList(string code)
        {
            var continent = service.FindContinentById(code);
            var countries = service.ExtractContinentCountriesWithAllData(continent);
            return View(countries);
        }
    }
}