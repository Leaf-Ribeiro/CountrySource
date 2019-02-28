using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountrySource.Application.Countries.Commands
{
    public class StateCreateCommand
    {
        public StateCreateCommand(string name, int? countryId)
        {
            Name = name;
            CountryId = countryId;
        }

        public string Name { get; set; }
        public int? CountryId { get; set; }
    }
}
