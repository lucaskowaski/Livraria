using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Domain.Models
{
    public class Livro: BaseEntity
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Idioma { get; set; }
        public int AnoPublicacao { get; set; }
        public int NumeroPaginas { get; set; }
    }
}
