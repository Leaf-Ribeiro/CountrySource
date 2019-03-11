using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CountrySource.Platform.Commands;
using CountrySource.Platform.Models;

namespace CountrySource.Web.ViewModels.States
{
    public class StateUpdateViewModel
    {
        public StateUpdateViewModel()
        {
            Countries = new List<CountryViewModel>();
        }

        public StateUpdateViewModel(Estado state, IList<Pais> countries) : this()
        {
            if (state != null)
            {
                Id = state.Id;
                Name = state.Nome;
                CountryId = state.Pais.Id;
            }

            if (countries != null && countries.Count > 0)
                countries.ToList().ForEach(item => { Countries.Add(new CountryViewModel(item.Id, item.Nome)); });
        }

        [Required]
        public int? Id { get; set; }

        [Display(Name = "Name", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceName = "NAME_REQUIRED", ErrorMessageResourceType = (typeof(Resources.Resources)))]
        public string Name { get; set; }

        [Display(Name = "Country", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceName = "COUNTRY_REQUIRED", ErrorMessageResourceType = (typeof(Resources.Resources)))]
        public int? CountryId { get; set; }
        public IList<CountryViewModel> Countries { get; set; }

        public EstadoUpdateCommand ToCommand()
        {
            return new EstadoUpdateCommand(Id, Name, CountryId);
        }

        public class CountryViewModel
        {
            public CountryViewModel(int id, string name)
            {
                Id = id;
                Name = name;
            }

            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}