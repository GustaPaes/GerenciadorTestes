using GerenciadorTestes.Dominio.ModuloDisciplina;
using GerenciadorTestes.WinApp.Compartilhado;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GerenciadorTestes.WinApp.ModuloDisciplina
{
    internal class ControladorDisciplina : ControladorBase
    {
        private readonly IRepositorioDisciplina repositorioDisciplina;
        private TabelaDisciplinaControl tabelaDisciplina;
        public ControladorDisciplina(IRepositorioDisciplina repositorioDisciplina)
        {
            this.repositorioDisciplina = repositorioDisciplina;
        }

        public override void Inserir()
        {
            TelaCadastroDisciplinasForm tela = new TelaCadastroDisciplinasForm();
            tela.Disciplina = new Disciplina();

            tela.GravarRegistro = repositorioDisciplina.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarDisciplinas();
            }
        }

        public override void Editar()
        {
            Disciplina disciplinaSelecionado = ObtemDisciplinaSelecionada();

            if (disciplinaSelecionado == null)
            {
                MessageBox.Show("Selecione uma disciplina primeiro",
                "Edição de Disciplinas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroDisciplinasForm tela = new TelaCadastroDisciplinasForm();

            tela.Disciplina = disciplinaSelecionado;

            tela.GravarRegistro = repositorioDisciplina.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarDisciplinas();
            }
        }

        public override void Excluir()
        {
            Disciplina disciplinaSelecionado = ObtemDisciplinaSelecionada();

            if (disciplinaSelecionado == null)
            {
                MessageBox.Show("Selecione uma disciplina primeiro",
                "Exclusão de Disciplinas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir a disciplina?",
                "Exclusão de Disciplinas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioDisciplina.Excluir(disciplinaSelecionado);
                CarregarDisciplinas();
            }
        }

        public override void Agrupar()
        {
            TelaAgrupamentoDisciplinaForm telaAgrupamento = new TelaAgrupamentoDisciplinaForm();

            if (telaAgrupamento.ShowDialog() == DialogResult.OK)
            {
                tabelaDisciplina.AgruparDisciplinas(telaAgrupamento.TipoAgrupamento);
            }
        }

        public override UserControl ObtemListagem()
        {
            tabelaDisciplina = new TabelaDisciplinaControl();

            CarregarDisciplinas();

            return tabelaDisciplina;
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxDiscplina();
        }

        private Disciplina ObtemDisciplinaSelecionada()
        {
            var numero = tabelaDisciplina.ObtemNumeroDisciplinasSelecionado();

            return repositorioDisciplina.SelecionarPorNumero(numero);
        }

        private void CarregarDisciplinas()
        {
            List<Disciplina> disciplinas = repositorioDisciplina.SelecionarTodos();

            tabelaDisciplina.AtualizarRegistros(disciplinas);

            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {disciplinas.Count} disciplina(s)");

        }
    }
}
