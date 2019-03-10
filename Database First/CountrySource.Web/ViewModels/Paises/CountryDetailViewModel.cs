using CountrySource.Platform.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public CountryDetailViewModel(Pais country) : this()
        {
            if (country != null)
            {
                Id = country.Id;
                Name = country.Nome;
                Continent = country.Continente;

                country.Estado.ToList().ForEach(item => { States.Add(new StateViewModel(item.Id, item.Nome)); });
            }
        }

        public int? Id { get; set; }
        [Display(Name = "Name", ResourceType = typeof(Resources.Language))]
        public string Name { get; set; }
        [Display(Name = "Continent", ResourceType = typeof(Resources.Language))]
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
            [Display(Name = "State", ResourceType = typeof(Resources.Language))]
            public string Name { get; set; }
        }
    }
}