using FluentValidation;
using System;

namespace GerenciadorTestes.Dominio.ModuloMateria
{
    public class ValidadorMateria : AbstractValidator<Materia>
    {
        public ValidadorMateria()
        {
            RuleFor(x => x.Nome)
                .NotNull().NotEmpty();

            RuleFor(x => x.Disciplina)
                .NotNull().NotEmpty();

            RuleFor(x => x.Serie)
                .NotNull().NotEmpty();

            RuleFor(x => x.DataCriacao)
                .NotEqual(DateTime.MinValue)
                .WithMessage("O campo Data de Criação é obrigatório");
        }
    }
}