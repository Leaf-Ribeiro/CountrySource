using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountrySource.Domain.Countries
{
    public class State
    {
        public State()
        {
            Cities = new List<City>();
        }

        public State(Country country, string name) : this()
        {
            Country = country;
            Name = name;
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Nome obrigatório.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Pais obrigatório.")]
        public Country Country { get; set; }
        public int CountryId { get; set; }

        public IList<City> Cities { get; set; }

        public void Update(string name, int? countryId)
        {
            if (!countryId.HasValue) throw new ArgumentNullException(nameof(countryId));
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));

            CountryId = countryId.Value;
            Name = name;
        }

        public void CreateCity(string cityName)
        {
            if (string.IsNullOrWhiteSpace(cityName)) throw new ArgumentNullException(nameof(cityName));

            var city = new City(this, cityName);

            Cities.Add(city);
        }
    }
}
