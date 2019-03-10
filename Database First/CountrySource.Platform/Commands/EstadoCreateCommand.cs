using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountrySource.Platform.Commands
{
    public class EstadoCreateCommand
    {
        public EstadoCreateCommand(string nome, int? paisId)
        {
            Nome = nome;
            PaisId = paisId;
        }

        public string Nome { get; set; }
        public int? PaisId { get; set; }
    }
}
