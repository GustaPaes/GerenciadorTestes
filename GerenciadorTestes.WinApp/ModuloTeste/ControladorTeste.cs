using GerenciadorTestes.Dominio.ModuloTeste;
using GerenciadorTestes.WinApp.Compartilhado;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GerenciadorTestes.WinApp.ModuloTeste
{
  

    internal class ControladorTeste : ControladorBase
    {
        private readonly IRepositorioTeste repositorioTeste;
        private TabelaTesteControl tabelaTeste;
        public ControladorTeste(IRepositorioTeste repositorioTeste)
        {
            this.repositorioTeste = repositorioTeste;
        }

        public override void Inserir()
        {
            TelaCadastroTestesForm tela = new TelaCadastroTestesForm();
            tela.Teste = new Teste();

            tela.GravarRegistro = repositorioTeste.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarTestes();
            }
        }

        public override void Editar()
        {
            Teste testeSelecionado = ObtemTesteSelecionada();

            if (testeSelecionado == null)
            {
                MessageBox.Show("Selecione um teste primeiro",
                "Edição de Testes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroTestesForm tela = new TelaCadastroTestesForm();

            tela.Teste = testeSelecionado;

            tela.GravarRegistro = repositorioTeste.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarTestes();
            }
        }

        public override void Excluir()
        {
            Teste testeSelecionado = ObtemTesteSelecionada();

            if (testeSelecionado == null)
            {
                MessageBox.Show("Selecione um teste primeiro",
                "Exclusão de Testes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir a teste?",
                "Exclusão de Testes", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioTeste.Excluir(testeSelecionado);
                CarregarTestes();
            }
        }

        public override void Agrupar()
        {
            TelaAgrupamentoTesteForm telaAgrupamento = new TelaAgrupamentoTesteForm();

            if (telaAgrupamento.ShowDialog() == DialogResult.OK)
            {
                tabelaTeste.AgruparTestes(telaAgrupamento.TipoAgrupamento);
            }
        }

        public override UserControl ObtemListagem()
        {
            tabelaTeste = new TabelaTesteControl();

            CarregarTestes();

            return tabelaTeste;
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxDiscplina();
        }

        private Teste ObtemTesteSelecionada()
        {
            var numero = tabelaTeste.ObtemNumeroTestesSelecionado();

            return repositorioTeste.SelecionarPorNumero(numero);
        }

        private void CarregarTestes()
        {
            List<Teste> testes = repositorioTeste.SelecionarTodos();

            tabelaTeste.AtualizarRegistros(testes);

            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {testes.Count} teste(s)");

        }
    }
}
