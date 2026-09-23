using Geography.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Geography.Web.Controllers
{
    public class CountriesController(ICountriesService service) : Controller
    {
        [HttpGet]
        public IActionResult Index()
            => View(service.GetAllCountries());
    }
}