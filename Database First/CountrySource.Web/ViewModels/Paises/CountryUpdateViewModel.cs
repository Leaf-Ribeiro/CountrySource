using CountrySource.Platform.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CountrySource.Platform.Models;

namespace CountrySource.Web.ViewModels.Countries
{
    public class CountryUpdateViewModel
    {
        public CountryUpdateViewModel()
        {
        }

        public CountryUpdateViewModel(Pais country) : this()
        {
            if (country != null)
            {
                Id = country.Id;
                Name = country.Nome;
                Continent = country.Continente;
            }
        }

        [Required]
        public int? Id { get; set; }
        [Display(Name = "Name", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceName = "COUNTRY_REQUIRED", ErrorMessageResourceType = typeof(Resources.Resources))]
        public string Name { get; set; }

        [Display(Name = "Continent", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceName = "CONTINENT_REQUIRED", ErrorMessageResourceType = typeof(Resources.Resources))]
        public string Continent { get; set; }


        public PaisUpdateCommand ToCommand()
        {
            return new PaisUpdateCommand(Id, Name, Continent);
        }
    }
}