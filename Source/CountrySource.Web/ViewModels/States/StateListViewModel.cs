using CountrySource.Domain.Countries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CountrySource.Web.ViewModels.States
{
    public class StateListViewModel
    {
        public StateListViewModel()
        {
            States = new List<StateViewModel>();
        }

        public string SearchText { get; set; }
        public IList<StateViewModel> States { get; set; }

        public void Load(IList<State> states)
        {
            if (states != null && states.Count > 0)
            {
                states.ToList().ForEach(item =>
                {
                    States.Add(new StateViewModel(item.Id, item.Name, item.Country.Name));
                });
            }
        }

        public class StateViewModel
        {
            public StateViewModel(int id, string name, string countryName)
            {
                Id = id;
                Name = name;
                CountryName = countryName;
            }

            public int Id { get; set; }
            public string Name { get; set; }
            public string CountryName { get; set; }
        }
    }
}