using CountrySource.Application.Countries.Commands;
using CountrySource.Domain.Countries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CountrySource.Web.ViewModels.States
{
    public class StateUpdateViewModel
    {
        public StateUpdateViewModel()
        {
            Countries = new List<CountryViewModel>();
        }

        public StateUpdateViewModel(State state, IList<Country> countries) : this()
        {
            if (state != null)
            {
                Id = state.Id;
                Name = state.Name;
                CountryId = state.CountryId;
            }

            if (countries != null && countries.Count > 0)
                countries.ToList().ForEach(item => { Countries.Add(new CountryViewModel(item.Id, item.Name)); });
        }

        [Required]
        public int? Id { get; set; }
        [Required(ErrorMessage = "Nome obrigatório")]
        public string Name { get; set; }
        [Required(ErrorMessage = "País obrigatório")]
        public int? CountryId { get; set; }
        public IList<CountryViewModel> Countries { get; set; }

        public StateUpdateCommand ToCommand()
        {
            return new StateUpdateCommand(Id, Name, CountryId);
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