using CountrySource.Domain.Countries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CountrySource.Web.ViewModels.Cities
{
    public class CityListViewModel
    {
        public CityListViewModel()
        {
            Cities = new List<CityViewModel>();
        }

        public string SearchText { get; set; }
        public IList<CityViewModel> Cities { get; set; }

        public void Load(IList<City> cities)
        {
            if (cities != null && cities.Count > 0)
            {
                cities.ToList().ForEach(item =>
                {
                    Cities.Add(new CityViewModel(item.Id, item.Name, item.State.Name));
                });
            }
        }

        public class CityViewModel
        {
            public CityViewModel(int id, string name, string stateName)
            {
                Id = id;
                Name = name;
                StateName = stateName;
            }

            public int Id { get; set; }
            public string Name { get; set; }
            public string StateName { get; set; }
        }
    }
}