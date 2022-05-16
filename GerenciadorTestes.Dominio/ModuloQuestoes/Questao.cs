using GerenciadorTestes.Dominio.Compartilhado;
using GerenciadorTestes.Dominio.ModuloDisciplina;
using GerenciadorTestes.Dominio.ModuloMateria;
using System;

namespace GerenciadorTestes.Dominio.ModuloQuestoes
{
    public class Questao : EntidadeBase<Questao>
    {
        public Questao()
        {
            HoraInicio = DateTime.Now;
        }

        public Questao(int numero, string enunciado, Disciplina disciplina, Materia materia)
        {
            Numero = numero;
            Enunciado = enunciado;
            Disciplinas = disciplina;
            Materias = materia;
        }

        public string Enunciado { get; set; }
        public DateTime HoraInicio { get; set; }
        public Disciplina Disciplinas { get; set; }
        public Materia Materias { get; set; }



        public override void Atualizar(Questao registro)
        {
        }
    }
}
