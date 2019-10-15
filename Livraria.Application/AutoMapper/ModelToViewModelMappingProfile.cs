using AutoMapper;
using Livraria.Application.ViewModels;
using Livraria.Domain.Models;
namespace Livraria.Application.AutoMapper
{
    public class ModelToViewModelMappingProfile : Profile
    {
        public ModelToViewModelMappingProfile()
        {
            CreateMap<Livro, LivroViewModel>();
        }
    }
}
