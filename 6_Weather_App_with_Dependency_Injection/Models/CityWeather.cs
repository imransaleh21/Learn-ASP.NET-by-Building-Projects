using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class CityWeather
    {
        public string CityUniqueCode { get; set; }
        public string CityName { get; set; }

        [Required(ErrorMessage = "{0} is can't be blank.")]
        public DateTime DateTime { get; set; }
        public int TemperatureFahrenheit { get; set; }
    }
}
