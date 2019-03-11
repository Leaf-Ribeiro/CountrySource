using CountrySource.Platform.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CountrySource.Web.ViewModels.Cidades
{
    public class CityListViewModel
    {
        public CityListViewModel()
        {
            Cidades = new List<CityViewModel>();
        }

        public string SearchText { get; set; }
        public IList<CityViewModel> Cidades { get; set; }

        public void Load(IList<Cidade> cidades)
        {
            if (cidades != null && cidades.Count > 0)
            {
                cidades.ToList().ForEach(item =>
                {
                    Cidades.Add(new CityViewModel(item.Id, item.Nome, item.Estado.Nome));
                });
            }
        }

        public class CityViewModel
        {
            public CityViewModel(int id, string nome, string estadoNome)
            {
                Id = id;
                Nome = nome;
                EstadoNome = estadoNome;
            }

            public int Id { get; set; }

            [Display(Name = "Name", ResourceType = typeof(Resources.Resources))]
            public string Nome { get; set; }

            [Display(Name = "State", ResourceType = typeof(Resources.Resources))]
            public string EstadoNome { get; set; }
        }
    }
}