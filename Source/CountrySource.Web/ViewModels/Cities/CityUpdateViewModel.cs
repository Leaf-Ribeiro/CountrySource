using CountrySource.Application.Countries.Commands;
using CountrySource.Domain.Countries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CountrySource.Web.ViewModels.Cities
{
    public class CityUpdateViewModel
    {
        public CityUpdateViewModel()
        {
            States = new List<StateViewModel>();
        }

        public CityUpdateViewModel(IList<State> states, City city) : this()
        {
            if (city != null)
            {
                Id = city.Id;
                Name = city.Name;
                StateId = city.StateId;
            }

            if (states != null && states.Count > 0)
                states.ToList().ForEach(item => { States.Add(new StateViewModel(item.Id, item.Name)); });
        }

        public int? Id { get; set; }
        public string Name { get; set; }
        [Required(ErrorMessage = "Estado obrigatório")]
        public int? StateId { get; set; }
        public IList<StateViewModel> States { get; set; }

        public CityUpdateCommand ToCommand()
        {
            return new CityUpdateCommand(Id, Name, StateId);
        }

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