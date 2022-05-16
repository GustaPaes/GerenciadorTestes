using FluentValidation;
using FluentValidation.Validators;
using System;

namespace GerenciadorTestes.Dominio.ModuloDisciplina
{
   
    public class ValidadorDisciplina : AbstractValidator<Disciplina>
    {       
        public ValidadorDisciplina()
        {
            RuleFor(x => x.Nome)
                .NotNull().NotEmpty();
        }

    }
}
