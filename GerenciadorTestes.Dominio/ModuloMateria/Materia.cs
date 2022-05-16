using GerenciadorTestes.Dominio.Compartilhado;
using GerenciadorTestes.Dominio.ModuloDisciplina;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GerenciadorTestes.Dominio.ModuloMateria
{
    [Serializable]
    public class Materia : EntidadeBase<Materia>
    {

        public Materia()
        {
            DataCriacao = DateTime.Now;
        }

        public Materia(int n, string nome, Disciplina d, string s) : this()
        {
            Numero = n;
            Nome = nome;
            Disciplina = d;
            Serie = s;
            DataConclusao = null;
        }

        public string Nome { get; set; }

        public Disciplina Disciplina { get; set; }

        public string Serie { get; set; }        

        public DateTime DataCriacao { get; set; }

        public DateTime? DataConclusao { get; set; }

        public override string ToString()
        {
            return $"Número: {Numero}, Nome: {Nome}, Disciplina: {Disciplina}, Série: {Serie}";
        }        

        public override void Atualizar(Materia registro)
        {
            this.Numero = registro.Numero;
            this.Nome = registro.Nome;
            this.Disciplina = registro.Disciplina;
            this.Serie = registro.Serie;
        }
    }
}
