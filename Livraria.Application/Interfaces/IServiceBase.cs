using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Application.Interfaces
{
    public interface IServiceBase<TEntity, TValidator> where TValidator : AbstractValidator<TEntity>
    {
        void Validate(TEntity obj);
        void ValidateId(int id);
    }
}
