using Livraria.Domain.Interfaces;
using Livraria.Domain.Models;
using Livraria.Infra.Data.Context;

namespace Livraria.Infra.Data.Repository
{
    public class LivroRepository: RepositoryBase<Livro>, ILivroRepository
    {
        public LivroRepository(LivrariaContext context)
            :base(context)
        {

        }
    }
}
