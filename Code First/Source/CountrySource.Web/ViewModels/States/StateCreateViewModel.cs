using CountrySource.Application.Countries.Commands;
using CountrySource.Domain.Countries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CountrySource.Web.ViewModels.States
{
    public class StateCreateViewModel
    {
        public StateCreateViewModel()
        {
            Countries = new List<CountryViewModel>();
        }

        public StateCreateViewModel(IList<Country> countries) : this()
        {
            if (countries != null && countries.Count > 0)
                countries.ToList().ForEach(item => { Countries.Add(new CountryViewModel(item.Id, item.Name)); });
        }

        [Required(ErrorMessage = "Nome obrigatório")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Pais obrigatório")]
        public int? CountryId { get; set; }

        public IList<CountryViewModel> Countries { get; set; }

        public StateCreateCommand ToCommand()
        {
            return new StateCreateCommand(Name, CountryId);
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