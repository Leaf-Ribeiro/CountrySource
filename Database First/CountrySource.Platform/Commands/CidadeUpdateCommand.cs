using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountrySource.Platform.Commands
{
    public class CidadeUpdateCommand
    {
        public CidadeUpdateCommand(int? id, string nome, int? estadoId)
        {
            Id = id;
            Nome = nome;
            EstadoId = estadoId;
        }

        public int? Id { get; set; }
        public string Nome { get; set; }
        public int? EstadoId { get; set; }
    }
}
