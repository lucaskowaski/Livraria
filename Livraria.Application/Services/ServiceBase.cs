using FluentValidation;
using Livraria.Application.Interfaces;
using System;

namespace Livraria.Application.Services
{
    public class ServiceBase<TEntity, TValidator>: IServiceBase<TEntity, TValidator> where TValidator: AbstractValidator<TEntity>
    {
        private readonly TValidator _validator;
        public ServiceBase()
        {
            _validator = Activator.CreateInstance<TValidator>();
        }
        public void Validate(TEntity obj)
        {
            _validator.ValidateAndThrow(obj);
        }
        public void ValidateId(int id)
        {
            if (id == 0)
                throw new ArgumentException("O id não pode ser 0");
        }
    }
}
