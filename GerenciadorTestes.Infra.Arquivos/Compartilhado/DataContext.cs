using GerenciadorTestes.Dominio.ModuloDisciplina;
using GerenciadorTestes.Dominio.ModuloMateria;
using GerenciadorTestes.Dominio.ModuloQuestoes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GerenciadorTestes.Infra.Arquivos
{
    [Serializable]
    public class DataContext //Container
    {
        private readonly ISerializador serializador;

        public DataContext()
        {
            Materias = new List<Materia>();

            Disciplinas = new List<Disciplina>();

            Questoes = new List<Questao>();
        }

        public DataContext(ISerializador serializador) : this()
        {
            this.serializador = serializador;

            CarregarDados();
        }

        public List<Materia> Materias { get; set; }

        public List<Disciplina> Disciplinas { get; set; }

        public List<Questao> Questoes { get; set; }

        public void GravarDados()
        {
            serializador.GravarDadosEmArquivo(this);
        }

        private void CarregarDados()
        {
            var ctx = serializador.CarregarDadosDoArquivo();

            if (ctx.Materias.Any())
                this.Materias.AddRange(ctx.Materias);

            if (ctx.Disciplinas.Any())
                this.Disciplinas.AddRange(ctx.Disciplinas);

            if (ctx.Questoes.Any())
                this.Questoes.AddRange(ctx.Questoes);
        }
    }
}
