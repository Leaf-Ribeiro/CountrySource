using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountrySource.Platform.Commands
{
    public class PaisCreateCommand
    {
        public PaisCreateCommand(string nome, string continente)
        {
            Nome = nome;
            Continente = continente;
        }

        public string Nome { get; set; }
        public string Continente { get; set; }
    }
}
