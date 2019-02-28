using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountrySource.Application.Countries.Commands
{
    public class CountryUpdateCommand
    {
        public CountryUpdateCommand(int? id, string name, string continent)
        {
            Id = id;
            Name = name;
            Continent = continent;
        }

        public int? Id { get; set; }
        public string Name { get; set; }
        public string Continent { get; set; }
    }
}
