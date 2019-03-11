using CountrySource.Platform.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CountrySource.Platform.Models;

namespace CountrySource.Web.ViewModels.States
{
    public class StateCreateViewModel
    {
        public StateCreateViewModel()
        {
            Countries = new List<CountryViewModel>();
        }

        public StateCreateViewModel(IList<Pais> countries) : this()
        {
            if (countries != null && countries.Count > 0)
                countries.ToList().ForEach(item => { Countries.Add(new CountryViewModel(item.Id, item.Nome)); });
        }


        [Display(Name = "Name", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceName = "NAME_REQUIRED", ErrorMessageResourceType = (typeof(Resources.Resources)))]
        public string Name { get; set; }

        [Display(Name = "Country", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceName = "COUNTRY_REQUIRED", ErrorMessageResourceType = (typeof(Resources.Resources)))]
        public int? CountryId { get; set; }

        public IList<CountryViewModel> Countries { get; set; }

        public EstadoCreateCommand ToCommand()
        {
            return new EstadoCreateCommand(Name, CountryId);
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