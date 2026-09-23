using Geography.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Geography.Web.Controllers
{
    public class ContinentsController(IContinentsService service) : Controller
    {
        [HttpGet]
        public IActionResult Index()
            => View(service.GetAllContinents());

        [HttpGet]
        public IActionResult CountriesList(string code)
        {
            var continent = service.FindContinentById(code);
            var countries = service.ExtractContinentCountriesWithAllData(continent);
            return View(countries);
        }
    }
}