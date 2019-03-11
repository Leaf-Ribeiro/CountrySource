using CountrySource.Platform.Commands;
using CountrySource.Platform.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using CountrySource.Resources;
using System.Web;

namespace CountrySource.Web.ViewModels.Cidades
{
    public class CityCreateViewModel
    {
        public CityCreateViewModel()
        {
            States = new List<StateViewModel>();
        }

        public CityCreateViewModel(IList<Estado> states) : this()
        {
            if (states != null && states.Count > 0)
                states.ToList().ForEach(item => { States.Add(new StateViewModel(item.Id, item.Nome)); });
        }

        [Display(Name = "Name", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceType = (typeof(Resources.Resources)), ErrorMessageResourceName = "NAME_REQUIRED")]
        public string Name { get; set; }
        [Required(ErrorMessageResourceType = (typeof(Resources.Resources)), ErrorMessageResourceName = "STATE_REQUIRED")]

        [Display(Name = "State", ResourceType = typeof(Resources.Resources))]
        public int? StateId { get; set; }
        public IList<StateViewModel> States { get; set; }

        public CidadeCreateCommand ToCommand()
        {
            return new CidadeCreateCommand(Name, StateId);
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