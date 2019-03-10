using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountrySource.Domain.Countries
{
    public class City
    {
        public City()
        {

        }

        public City(State state, string name)
        {
            Name = name;
            State = state;
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Nome obrigatório.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Estado obrigatório.")]
        public State State { get; set; }
        public int StateId { get; set; }

        public void Update(string name, int? stateId)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            if (!stateId.HasValue) throw new ArgumentNullException(nameof(stateId));

            Name = name;
            StateId = stateId.Value;
        }
    }
}
