
using Models;
using ServicesBluePrints;

namespace Services
{
    public class CityWeathersService : ICityWeathersService
    {
        private readonly List<CityWeather> _cityWeathers;
        public CityWeathersService()
        {
            _cityWeathers = new()
                   {
                       new() { CityUniqueCode = "NYC", CityName = "New York", DateTime = DateTime.Now, TemperatureFahrenheit = 75 },
                       new() { CityUniqueCode = "LAX", CityName = "Los Angeles", DateTime = DateTime.Now, TemperatureFahrenheit = 80 },
                       new() { CityUniqueCode = "CHI", CityName = "Chicago", DateTime = DateTime.Now, TemperatureFahrenheit = 70 }
                   };
        }

        public List<CityWeather> GetWeatherDetails()
        {
            return _cityWeathers;
        }

        public CityWeather? GetWeatherByCity(string? cityUniqueCode)
        {
            if (cityUniqueCode == null) return null;
            var city = _cityWeathers.FirstOrDefault(c =>c.CityUniqueCode.Equals(cityUniqueCode, StringComparison.OrdinalIgnoreCase));

            if (city != null)
            {
                city.TemperatureFahrenheit -= 5;
            }

            return city;
        }
    }
}
