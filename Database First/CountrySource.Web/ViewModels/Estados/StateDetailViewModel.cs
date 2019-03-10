using CountrySource.Platform.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CountrySource.Web.ViewModels.States
{
    public class StateDetailViewModel
    {
        public StateDetailViewModel()
        {
            Cities = new List<CityViewModel>();
        }

        public StateDetailViewModel(Estado state) : this()
        {
            if (state != null)
            {
                Id = state.Id;
                Name = state.Nome;
                CountryName = state.Pais.Nome;

                state.Cidade.ToList().ForEach(item => { Cities.Add(new CityViewModel(item.Id, item.Nome)); });
            }
        }

        public int? Id { get; set; }

        [Display(Name = "Name", ResourceType = typeof(Resources.Language))]
        public string Name { get; set; }

        [Display(Name = "Country", ResourceType = typeof(Resources.Language))]
        public string CountryName { get; set; }
        public IList<CityViewModel> Cities { get; set; }

        public class CityViewModel
        {
            public CityViewModel(int? id, string name)
            {
                Id = id;
                Name = name;
            }

            public int? Id { get; set; }
            public string Name { get; set; }
        }
    }
}