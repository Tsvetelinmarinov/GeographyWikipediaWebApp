using Geography.Services;
using Microsoft.AspNetCore.Mvc;

namespace Geography.Web.Controllers
{
    public class ContinentsController(IContinentsService service) : Controller
    {
        public IActionResult Index()
            => View(service.GetAllContinents());
    }
}