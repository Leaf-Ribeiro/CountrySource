using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountrySource.Application.Countries.Commands
{
    public class CityUpdateCommand
    {
        public CityUpdateCommand(int? id, string name, int? stateId)
        {
            Id = id;
            Name = name;
            StateId = stateId;
        }

        public int? Id { get; set; }
        public string Name { get; set; }
        public int? StateId { get; set; }
    }
}
