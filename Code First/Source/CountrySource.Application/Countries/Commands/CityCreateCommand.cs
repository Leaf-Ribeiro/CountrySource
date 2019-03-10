using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountrySource.Application.Countries.Commands
{
    public class CityCreateCommand
    {
        public CityCreateCommand(string name, int? stateId)
        {
            Name = name;
            StateId = stateId;
        }
        
        public string Name { get; set; }
        public int? StateId { get; set; }
    }
}
