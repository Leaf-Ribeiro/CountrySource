using CountrySource.Application.Countries.Commands;
using CountrySource.Domain.Countries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CountrySource.Web.ViewModels.Cities
{
    public class CityCreateViewModel
    {
        public CityCreateViewModel()
        {
            States = new List<StateViewModel>();
        }

        public CityCreateViewModel(IList<State> states) : this()
        {
            if (states != null && states.Count > 0)
                states.ToList().ForEach(item => { States.Add(new StateViewModel(item.Id, item.Name)); });
        }

        public string Name { get; set; }
        [Required(ErrorMessage = "Estado obrigatório")]
        public int? StateId { get; set; }
        public IList<StateViewModel> States { get; set; }

        public CityCreateCommand ToCommand()
        {
            return new CityCreateCommand(Name, StateId);
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