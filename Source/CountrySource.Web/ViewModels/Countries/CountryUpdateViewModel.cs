using CountrySource.Application.Countries.Commands;
using CountrySource.Domain.Countries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CountrySource.Web.ViewModels.Countries
{
    public class CountryUpdateViewModel
    {
        public CountryUpdateViewModel()
        {
        }

        public CountryUpdateViewModel(Country country) : this()
        {
            if (country != null)
            {
                Id = country.Id;
                Name = country.Name;
                Continent = country.Continent;
            }
        }

        [Required]
        public int? Id { get; set; }
        [Required(ErrorMessage = "Nome obrigatório")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Continente obrigatório")]
        public string Continent { get; set; }


        public CountryUpdateCommand ToCommand()
        {
            return new CountryUpdateCommand(Id, Name, Continent);
        }
    }
}