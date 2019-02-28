using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountrySource.Application.Countries.Commands
{
    public class StateUpdateCommand
    {
        public StateUpdateCommand(int? id, string name, int? countryId)
        {
            Id = id;
            Name = name;
            CountryId = countryId;
        }

        public int? Id { get; set; }
        public string Name { get; set; }
        public int? CountryId { get; set; }
    }
}
