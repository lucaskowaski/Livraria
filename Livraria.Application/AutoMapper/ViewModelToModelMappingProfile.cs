using AutoMapper;
using Livraria.Application.ViewModels;
using Livraria.Domain.Models;
namespace Livraria.Application.AutoMapper
{
    public class ViewModelToModelMappingProfile : Profile
    {
        public ViewModelToModelMappingProfile()
        {
            CreateMap<LivroViewModel, Livro>();
        }
    }
}
