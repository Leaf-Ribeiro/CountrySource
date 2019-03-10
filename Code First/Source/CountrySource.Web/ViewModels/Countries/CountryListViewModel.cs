using CountrySource.Domain.Countries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CountrySource.Web.ViewModels.Countries
{
    public class CountryListViewModel
    {
        public CountryListViewModel()
        {
            Countries = new List<CountryViewModel>();
        }

        public string SearchText { get; set; }
        public IList<CountryViewModel> Countries { get; set; }

        public void Load(IList<Country> countries)
        {
            if (countries != null && countries.Count > 0)
            {
                countries.ToList().ForEach(item =>
                {
                    Countries.Add(new CountryViewModel(item.Id, item.Name, item.Continent));
                });
            }
        }

        public class CountryViewModel
        {
            public CountryViewModel(int id, string name, string continent)
            {
                Id = id;
                Name = name;
                Continent = continent;
            }

            public int Id { get; set; }
            public string Name { get; set; }
            public string Continent { get; set; }
        }
    }
}