using CountrySource.Domain.Countries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CountrySource.Web.ViewModels.Countries
{
    public class CountryDetailViewModel
    {
        public CountryDetailViewModel()
        {
            States = new List<StateViewModel>();
        }

        public CountryDetailViewModel(Country country) : this()
        {
            if (country != null)
            {
                Id = country.Id;
                Name = country.Name;
                Continent = country.Continent;

                country.States.ToList().ForEach(item => { States.Add(new StateViewModel(item.Id, item.Name)); });
            }
        }

        public int? Id { get; set; }
        public string Name { get; set; }
        public string Continent { get; set; }
        public IList<StateViewModel> States { get; set; }

        public class StateViewModel
        {
            public StateViewModel(int? id, string name)
            {
                Id = id;
                Name = name;
            }

            public int? Id { get; set; }
            public string Name { get; set; }
        }
    }
}