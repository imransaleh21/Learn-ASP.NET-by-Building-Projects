using Microsoft.AspNetCore.Mvc;
using ServicesBluePrints;

namespace _6_Weather_App_with_Dependency_Injection.Controllers
{
    public class CityWeathersController : Controller
    {

        private readonly ICityWeathersService _cityWeathersService;
        public CityWeathersController(ICityWeathersService weatherUpdate)
        {
            _cityWeathersService = weatherUpdate;
        }

        [Route("/")]
        public IActionResult Home()
        {
            return Json(_cityWeathersService.GetWeatherDetails());
        }

        [Route("/City/{cityUniqueCode}")]
        public IActionResult City(string? cityUniqueCode)
        {
            return Json(_cityWeathersService.GetWeatherByCity(cityUniqueCode));
        }
    }
}
