using GerenciadorTestes.Dominio.ModuloTeste;
using GerenciadorTestes.WinApp.Compartilhado;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GerenciadorTestes.WinApp.ModuloTeste
{
    

    public partial class TabelaTesteControl : UserControl
    {

        Subro.Controls.DataGridViewGrouper agrupadorContatos;
        private AgrupamentoTesteEnum tipoAgrupamento;

        public TabelaTesteControl()
        {
            InitializeComponent();

            grid.ConfigurarGridSomenteLeitura();
            grid.ConfigurarGridZebrado();
            grid.Columns.AddRange(ObterColunas());

            tipoAgrupamento = AgrupamentoTesteEnum.NaoAgrupar;
        }

        private DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Numero", HeaderText = "Número"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Titulo", HeaderText = "Titulo"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Data", HeaderText = "Data"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Disciplina", HeaderText = "Disciplina"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Materia", HeaderText = "Materia"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Questoes", HeaderText = "Quantidade de Questões"},
            };

            return colunas;
        }

        public int ObtemNumeroTestesSelecionado()
        {
            return grid.SelecionarNumero<int>();
        }

        public void AtualizarRegistros(List<Teste> contatos)
        {
            DesagruparContatos();

            grid.DataSource = contatos;

            agrupadorContatos = new Subro.Controls.DataGridViewGrouper(grid);
            
            AgruparContatos();
        }       

        public void DesagruparContatos()
        {
            if (agrupadorContatos == null)
                return;

            var campos = new string[] { "Cargo", "Empresa" };

            agrupadorContatos.RemoveGrouping();
            grid.RowHeadersVisible = true;

            foreach (var campo in campos)
                foreach (DataGridViewColumn item in grid.Columns)
                    if (item.DataPropertyName == campo)
                        item.Visible = true;
        }

        public void AgruparTestes(AgrupamentoTesteEnum tipoAgrupamento)
        {
            this.tipoAgrupamento = tipoAgrupamento;

            AgruparContatos();
        }

        private void AgruparContatos()
        {
            switch (tipoAgrupamento)
            {
                case AgrupamentoTesteEnum.AgruparPorEmpresa:
                    AgruparContatosPor("Empresa");
                    break;

                case AgrupamentoTesteEnum.AgruparPorCargo:
                    AgruparContatosPor("Cargo");
                    break;

                case AgrupamentoTesteEnum.NaoAgrupar:
                    DesagruparContatos();
                    break;

                default:
                    break;
            }
        }

        private void AgruparContatosPor(string campo)
        {
            if (agrupadorContatos == null)
                return;

            agrupadorContatos.RemoveGrouping();
            agrupadorContatos.SetGroupOn(campo);
            agrupadorContatos.Options.ShowGroupName = false;
            agrupadorContatos.Options.GroupSortOrder = SortOrder.None;

            foreach (DataGridViewColumn item in grid.Columns)
                if (item.DataPropertyName == campo)
                    item.Visible = false;

            grid.RowHeadersVisible = false;
            grid.ClearSelection();
        }


    }
}
