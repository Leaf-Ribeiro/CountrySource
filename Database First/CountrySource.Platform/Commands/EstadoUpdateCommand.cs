using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountrySource.Platform.Commands
{
    public class EstadoUpdateCommand
    {
        public EstadoUpdateCommand(int? id, string nome, int? paisId)
        {
            Id = id;
            Nome = nome;
            PaisId = paisId;
        }

        public int? Id { get; set; }
        public string Nome { get; set; }
        public int? PaisId { get; set; }
    }
}
