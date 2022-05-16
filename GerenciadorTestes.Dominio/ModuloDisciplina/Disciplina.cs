using GerenciadorTestes.Dominio.Compartilhado;
using System;

namespace GerenciadorTestes.Dominio.ModuloDisciplina
{
    public class Disciplina : EntidadeBase<Disciplina>
    {
        public Disciplina()
        {
            DataCriacao = DateTime.Now;
        }

        public Disciplina(int n, string nome) : this()
        {
            Numero = n;
            Nome = nome;
        }

        public string Nome { get; set; }

        public DateTime DataCriacao { get; set; }

        public override string ToString()
        {
            return $"Número: {Numero}, Nome: {Nome}";
        }

        public override void Atualizar(Disciplina registro)
        {
            this.Nome = registro.Nome;
        }
    }
}
