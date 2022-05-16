using GerenciadorTestes.Dominio.ModuloDisciplina;
using GerenciadorTestes.WinApp.Compartilhado;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GerenciadorTestes.WinApp.ModuloDisciplina
{
    

    public partial class TabelaDisciplinaControl : UserControl
    {

        Subro.Controls.DataGridViewGrouper agrupadorContatos;
        private AgrupamentoDisciplinaEnum tipoAgrupamento;

        public TabelaDisciplinaControl()
        {
            InitializeComponent();

            grid.ConfigurarGridSomenteLeitura();
            grid.ConfigurarGridZebrado();
            grid.Columns.AddRange(ObterColunas());

            tipoAgrupamento = AgrupamentoDisciplinaEnum.NaoAgrupar;
        }

        private DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Numero", HeaderText = "Número"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Telefone", HeaderText = "Telefone"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Empresa", HeaderText = "Empresa"},

                new DataGridViewTextBoxColumn {DataPropertyName = "Cargo", HeaderText = "Cargo"}
            };

            return colunas;
        }

        public int ObtemNumeroDisciplinasSelecionado()
        {
            return grid.SelecionarNumero<int>();
        }

        public void AtualizarRegistros(List<Disciplina> contatos)
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

        public void AgruparDisciplinas(AgrupamentoDisciplinaEnum tipoAgrupamento)
        {
            this.tipoAgrupamento = tipoAgrupamento;

            AgruparContatos();
        }

        private void AgruparContatos()
        {
            switch (tipoAgrupamento)
            {
                case AgrupamentoDisciplinaEnum.AgruparPorEmpresa:
                    AgruparContatosPor("Empresa");
                    break;

                case AgrupamentoDisciplinaEnum.AgruparPorCargo:
                    AgruparContatosPor("Cargo");
                    break;

                case AgrupamentoDisciplinaEnum.NaoAgrupar:
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
