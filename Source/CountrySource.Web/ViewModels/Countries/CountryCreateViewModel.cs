using CountrySource.Application.Countries.Commands;
using CountrySource.Domain.Countries;
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

        [Required(ErrorMessage = "Nome obrigatório")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Continente obrigatório")]
        public string Continent { get; set; }

        public CountryCreateCommand ToCommand()
        {
            return new CountryCreateCommand(Name, Continent);
        }
    }
}