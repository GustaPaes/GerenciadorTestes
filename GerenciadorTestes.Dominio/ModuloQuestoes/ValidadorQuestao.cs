using FluentValidation;
using System;

namespace GerenciadorTestes.Dominio.ModuloQuestoes
{
    public class ValidadorQuestao : AbstractValidator<Questao>
    {
        public ValidadorQuestao()
        {
            RuleFor(x => x.Enunciado)
               .NotNull().NotEmpty();
        }
    }
}
