using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountrySource.Platform.Models
{
    public partial class Pais
    {
        public Pais(string nome, string continente)
        {
            if (string.IsNullOrWhiteSpace(nome)) throw new ArgumentNullException(nameof(nome));
            if (string.IsNullOrWhiteSpace(continente)) throw new ArgumentNullException(nameof(continente));

            Nome = nome;
            Continente = continente;
        }

        public void Update(string nome, string continente)
        {
            if (string.IsNullOrWhiteSpace(nome)) throw new ArgumentNullException(nameof(nome));
            if (string.IsNullOrWhiteSpace(continente)) throw new ArgumentNullException(nameof(continente));

            Nome = nome;
            Continente = continente;
        }
    }
}
