using CountrySource.Platform.Commands;
using CountrySource.Platform.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CountrySource.Web.ViewModels.Cidades
{
    public class CityUpdateViewModel
    {
        public CityUpdateViewModel()
        {
            States = new List<StateViewModel>();
        }

        public CityUpdateViewModel(IList<Estado> states, Cidade city) : this()
        {
            if (city != null)
            {
                Id = city.Id;
                Name = city.Nome;
                StateId = city.Estado.Id;
            }

            if (states != null && states.Count > 0)
                states.ToList().ForEach(item => { States.Add(new StateViewModel(item.Id, item.Nome)); });
        }

        public int? Id { get; set; }

        [Display(Name = "Name", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceType = (typeof(Resources.Resources)), ErrorMessageResourceName = "NAME_REQUIRED")]
        public string Name { get; set; }

        [Display(Name = "Name", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceType = (typeof(Resources.Resources)), ErrorMessageResourceName = "STATE_REQUIRED")]
        public int? StateId { get; set; }
        public IList<StateViewModel> States { get; set; }

        public CidadeUpdateCommand ToCommand()
        {
            return new CidadeUpdateCommand(Id, Name, StateId);
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