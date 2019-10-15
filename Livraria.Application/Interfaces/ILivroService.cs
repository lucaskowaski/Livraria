using Livraria.Application.Validations;
using Livraria.Application.ViewModels;
using Livraria.Domain.Models;
using System.Collections.Generic;

namespace Livraria.Application.Interfaces
{
    public interface ILivroService: IServiceBase<Livro, LivroValidator>
    {
        void Add(LivroViewModel livro);
        LivroViewModel Get(int id);
        IEnumerable<LivroViewModel> GetAll();
        void Update(LivroViewModel livro);
        void Remove(int id);
    }
}
