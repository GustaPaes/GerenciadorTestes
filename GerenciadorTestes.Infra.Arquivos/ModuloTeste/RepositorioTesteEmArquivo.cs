using GerenciadorTestes.Dominio.ModuloMateria;
using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace GerenciadorTestes.Infra.Arquivos.ModuloMateria
{
    public class RepositorioTesteEmArquivo : RepositorioEmArquivoBase<Materia>, IRepositorioTeste
    {
        public RepositorioTesteEmArquivo(DataContext dataContext) : base(dataContext)
        {
            if (dataContext.Materias.Count > 0)
                contador = dataContext.Materias.Max(x => x.Numero);
        }

        public override ValidationResult Inserir(Teste novoRegistro)
        {
            var resultadoValidacao = Validar(novoRegistro);

            if (resultadoValidacao.IsValid)
            {
                novoRegistro.Numero = ++contador;

                var registros = ObterRegistros();

                registros.Add(novoRegistro);
            }

            return resultadoValidacao;
        }

        public override ValidationResult Editar(Teste registro)
        {
            var resultadoValidacao = Validar(registro);

            if (resultadoValidacao.IsValid)
            {
                var registros = ObterRegistros();

                foreach (var item in registros)
                {
                    if (item.Numero == registro.Numero)
                    {
                        item.Atualizar(registro);
                        break;
                    }
                }
            }

            return resultadoValidacao;
        }

        private ValidationResult Validar(Teste registro)
        {
            var validator = ObterValidador();

            var resultadoValidacao = validator.Validate(registro);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            var nomeEncontrado = ObterRegistros()
               .Select(x => x.Titulo)
               .Contains(registro.Titulo);


            if (nomeEncontrado && registro.Numero == 0)
                resultadoValidacao.Errors.Add(new ValidationFailure("", "Nome já está cadastrado"));

            return resultadoValidacao;
        }

        public override List<Materia> ObterRegistros()
        {
            return dataContext.Materias;
        }       

        public List<Teste> SelecionarTodoss()
        {
            return base.SelecionarTodos()
                .ToList();
        }

        public override List<Teste> SelecionarTodos()
        {
            return base.SelecionarTodos()
                .ToList();
        }
       

        public override AbstractValidator<Teste> ObterValidador()
        {
            return new ValidadorMateria();
        }
    }
}
