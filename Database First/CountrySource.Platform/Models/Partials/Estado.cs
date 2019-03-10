using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountrySource.Platform.Models
{
    public partial class Estado
    {
        public Estado(string nome, Pais pais)
        {
            if (pais == null) throw new ArgumentNullException(nameof(pais));
            if (string.IsNullOrWhiteSpace(nome)) throw new ArgumentNullException(nameof(nome));

            Pais = pais;
            Nome = nome;
        }

        public void Update(string nome, Pais pais)
        {
            if (pais == null) throw new ArgumentNullException(nameof(pais));
            if (string.IsNullOrWhiteSpace(nome)) throw new ArgumentNullException(nameof(nome));

            Pais = pais;
            Nome = nome;
        }
    }
}
