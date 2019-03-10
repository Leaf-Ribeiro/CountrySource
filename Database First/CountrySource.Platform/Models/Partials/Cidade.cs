using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountrySource.Platform.Models
{
    public partial class Cidade
    {
        public Cidade()
        {

        }

        public Cidade(string nome, Estado estado)
        {
            if (string.IsNullOrWhiteSpace(nome)) throw new ArgumentNullException(nameof(nome));
            if (estado == null) throw new ArgumentNullException(nameof(estado));

            Nome = nome;
            Estado = estado;
        }

        public void Update(string nome, Estado estado)
        {
            if (string.IsNullOrWhiteSpace(nome)) throw new ArgumentNullException(nameof(nome));
            if (estado == null) throw new ArgumentNullException(nameof(estado));

            Nome = nome;
            Estado = estado;
        }
    }
}
