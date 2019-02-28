using CountrySource.Domain.Countries;
using System;
using System.Collections.Generic;
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

        public StateDetailViewModel(State state) : this()
        {
            if (state != null)
            {
                Id = state.Id;
                Name = state.Name;
                CountryName = state.Country.Name;

                state.Cities.ToList().ForEach(item => { Cities.Add(new CityViewModel(item.Id, item.Name)); });
            }
        }

        public int? Id { get; set; }
        public string Name { get; set; }
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