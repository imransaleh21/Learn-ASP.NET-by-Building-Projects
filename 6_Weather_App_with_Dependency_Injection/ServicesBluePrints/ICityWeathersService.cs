using Models;

namespace ServicesBluePrints
{
    public interface ICityWeathersService
    {
        List<CityWeather> GetWeatherDetails();
        CityWeather GetWeatherByCity(string cityUniqueCode);
    }
}
