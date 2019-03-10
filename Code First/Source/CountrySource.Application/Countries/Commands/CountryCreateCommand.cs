using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountrySource.Application.Countries.Commands
{
    public class CountryCreateCommand
    {
        public CountryCreateCommand(string name, string continent)
        {
            Name = name;
            Continent = continent;
        }

        public string Name { get; set; }
        public string Continent { get; set; }
    }
}
