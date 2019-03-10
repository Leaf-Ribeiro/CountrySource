using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountrySource.Platform.Commands
{
    public class PaisUpdateCommand
    {
        public PaisUpdateCommand(int? id, string nome, string continente)
        {
            Id = id;
            Nome = nome;
            Continente = continente;
        }

        public int? Id { get; set; }
        public string Nome { get; set; }
        public string Continente { get; set; }
    }
}
