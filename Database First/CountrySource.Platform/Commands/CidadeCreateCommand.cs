using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountrySource.Platform.Commands
{
    public class CidadeCreateCommand
    {
        public CidadeCreateCommand(string nome, int? estadoId)
        {
            Nome = nome;
            EstadoId = estadoId;
        }
        
        public string Nome { get; set; }
        public int? EstadoId { get; set; }
    }
}
