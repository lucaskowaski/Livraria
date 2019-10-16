using Livraria.Application.ViewModels;
using Livraria.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Livraria.Aplication.Tests.Services
{
    static public class LivroFakes
    {
        static public IQueryable<Livro> livros => new List<Livro>()
        {
            new Livro()
            {
                Id = 1,
                Titulo = "Working effectively with legacy code",
                Autor = "Erich Gamma",
                Idioma = "inglês",
                AnoPublicacao = 2015,
                NumeroPaginas = 512
            },
              new Livro()
            {
                Id = 2,
                Titulo = "Design Patterns",
                Autor = "Ralph Johnson",
                Idioma = "inglês",
                AnoPublicacao = 2013,
                NumeroPaginas = 278
            },
            new Livro()
            {
                Id = 3,
                Titulo = "Clean Code",
                Autor = "Robert C. Martin",
                Idioma = "Português",
                AnoPublicacao = 2010,
                NumeroPaginas = 492
            }
        }.AsQueryable();
        static public LivroViewModel livroVmInvalida => new LivroViewModel()
        {
            Id = 0,
            Titulo = "",
            Autor = "",
            Idioma = "",
            AnoPublicacao = 0,
            NumeroPaginas = 0
        };
    }
}
