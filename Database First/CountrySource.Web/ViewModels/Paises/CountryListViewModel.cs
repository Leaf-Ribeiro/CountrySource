using CountrySource.Platform.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public void Load(IList<Pais> countries)
        {
            if (countries != null && countries.Count > 0)
            {
                countries.ToList().ForEach(item =>
                {
                    Countries.Add(new CountryViewModel(item.Id, item.Nome, item.Continente));
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
            [Display(Name = "Name", ResourceType = typeof(Resources.Resources))]
            public string Name { get; set; }
            [Display(Name = "Continent", ResourceType = typeof(Resources.Resources))]
            public string Continent { get; set; }
        }
    }
}