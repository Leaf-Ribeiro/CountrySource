using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountrySource.Domain.Countries
{
    public class Country
    {
        public Country()
        {
            States = new List<State>();
        }

        public Country(string name, string continent) : this()
        {
            Name = name;
            Continent = continent;
        }


        public int Id { get; set; }
        [Required(ErrorMessage = "Nome obrigatório.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Contiente obrigatório.")]
        public string Continent { get; set; }

        public IList<State> States { get; set; }

        public void Update(string name, string continent)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            if (string.IsNullOrWhiteSpace(continent)) throw new ArgumentNullException(nameof(continent));

            Name = name;
            Continent = continent;
        }

        public void CrateState(string stateName)
        {
            if (string.IsNullOrWhiteSpace(stateName)) throw new ArgumentNullException(nameof(stateName));

            var state = new State(this, stateName);

            States.Add(state);
        }
    }
}
