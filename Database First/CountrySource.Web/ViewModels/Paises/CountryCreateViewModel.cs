using CountrySource.Platform.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CountrySource.Web.ViewModels.Countries
{
    public class CountryCreateViewModel
    {
        public CountryCreateViewModel()
        {
        }

        [Display(Name = "Name", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceName = "COUNTRY_REQUIRED", ErrorMessageResourceType = typeof(Resources.Resources))]
        public string Name { get; set; }

        [Display(Name = "Continent", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceName = "CONTINENT_REQUIRED", ErrorMessageResourceType = typeof(Resources.Resources))]
        public string Continent { get; set; }

        public PaisCreateCommand ToCommand()
        {
            return new PaisCreateCommand(Name, Continent);
        }
    }
}