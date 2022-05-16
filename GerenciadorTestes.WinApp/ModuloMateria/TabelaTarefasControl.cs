using GerenciadorTestes.Dominio.ModuloMateria;
using GerenciadorTestes.WinApp.Compartilhado;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GerenciadorTestes.WinApp.ModuloMateria
{
    public partial class TabelaMateriasControl : UserControl
    {
        public TabelaMateriasControl()
        {
            InitializeComponent();
            grid.ConfigurarGridZebrado();
            grid.ConfigurarGridSomenteLeitura();
            grid.Columns.AddRange(ObterColunas());
        }

        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Numero", HeaderText = "Número"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Materias", HeaderText = "Matéria"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Disciplina", HeaderText = "Disciplina"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Serie", HeaderText = "Série"},

                new DataGridViewTextBoxColumn { DataPropertyName = "DataCriacao", HeaderText = "Criada em"},
            };

            return colunas;
        }

        public int ObtemNumeroMateriaSelecionado()
        {
            return grid.SelecionarNumero<int>();
        }

        public void AtualizarRegistros(List<Materia> materias)
        {
            grid.Rows.Clear();

            foreach (Materia materia in materias)
            {
                grid.Rows.Add(materia.Numero, materia.Nome, materia.Disciplina, materia.Serie, 
                    materia.DataCriacao);
            }
        }


    }
}
