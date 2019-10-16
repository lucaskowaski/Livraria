using AutoMapper;
using AutoMapper.QueryableExtensions;
using Livraria.Application.Interfaces;
using Livraria.Application.Validations;
using Livraria.Application.ViewModels;
using Livraria.Domain.Interfaces;
using Livraria.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace Livraria.Application.Services
{
    public class LivroService : ServiceBase<Livro, LivroValidator>, ILivroService
    {
        private readonly IMapper _mapper;
        private readonly ILivroRepository _livroRepository;
        public LivroService(IMapper mapper, ILivroRepository livroRepository)
        {
            _mapper = mapper;
            _livroRepository = livroRepository;
        }
        public void Add(LivroViewModel livroVm)
        {
            var livro = _mapper.Map<Livro>(livroVm);
            Validate(livro);
            _livroRepository.Add(livro);
        }

        public void Update(LivroViewModel livroVm)
        {
            var livro = _mapper.Map<Livro>(livroVm);
            Validate(livro, "default,id");
            _livroRepository.Update(livro);
        }
        public LivroViewModel Get(int id)
        {
            ValidateId(id);
            return _mapper.Map<LivroViewModel>(_livroRepository.Get(id));
        }

        public IEnumerable<LivroViewModel> GetAll()
        {
            return _livroRepository.GetAll()
                .OrderBy(l=>l.Titulo)
                .ProjectTo<LivroViewModel>(_mapper.ConfigurationProvider);
        }

        public void Remove(int id)
        {
            ValidateId(id);
            _livroRepository.Remove(id);
        }
    }
}
