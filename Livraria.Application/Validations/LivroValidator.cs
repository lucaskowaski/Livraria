using FluentValidation;
using Livraria.Domain.Models;
using System;

namespace Livraria.Application.Validations
{
    public class LivroValidator : AbstractValidator<Livro>
    {
        public LivroValidator()
        {
            RuleFor(l => l)
               .NotNull()
               .OnAnyFailure(x =>
               {
                   throw new ArgumentNullException(nameof(Livro));
               });
            const string NULL_OR_EMPTY_MESSAGE = "É necessário informar {0}";

            string TITULO_NULL_OR_EMPTY_MESSAGE = string.Format(NULL_OR_EMPTY_MESSAGE, "O Título");
            RuleFor(l => l.Titulo)
                .NotEmpty().WithMessage(TITULO_NULL_OR_EMPTY_MESSAGE)
                .NotNull().WithMessage(TITULO_NULL_OR_EMPTY_MESSAGE)
                .MinimumLength(3).WithMessage("O Título de ter no minimo 3 caracteres")
                .MaximumLength(100).WithMessage("O Título de ter no máximo 100 caracteres");

            string AUTOR_NULL_OR_EMPTY_MESSAGE = string.Format(NULL_OR_EMPTY_MESSAGE, "O Autor");
            RuleFor(l => l.Autor)
                .NotEmpty().WithMessage(AUTOR_NULL_OR_EMPTY_MESSAGE)
                .NotNull().WithMessage(AUTOR_NULL_OR_EMPTY_MESSAGE)
                .MinimumLength(3).WithMessage("O Autor de ter no minimo 3 caracteres")
                .MaximumLength(100).WithMessage("O Autor de ter no máximo 100 caracteres");

            string IDIOMA_NULL_OR_EMPTY_MESSAGE = string.Format(NULL_OR_EMPTY_MESSAGE, "O Idioma");
            RuleFor(l => l.Idioma)
                .NotEmpty().WithMessage(IDIOMA_NULL_OR_EMPTY_MESSAGE)
                .NotNull().WithMessage(IDIOMA_NULL_OR_EMPTY_MESSAGE)
                .MinimumLength(3).WithMessage("O Idioma de ter no minimo 3 caracteres")
                .MaximumLength(100).WithMessage("O Idioma de ter no máximo 100 caracteres");
            RuleFor(l => l.AnoPublicacao)
                .InclusiveBetween(0, int.MaxValue).WithMessage("O Ano de publicação requer um ano válido");
            RuleFor(l => l.NumeroPaginas)
                .InclusiveBetween(0, int.MaxValue).WithMessage("O Numero de Páginas requer um numero válido");

            RuleSet("id", () => {
                RuleFor(x => x.Id)
                .GreaterThan(0);
            });
        }
    }
}
