using GerenciadorTestes.Dominio.ModuloMateria;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GerenciadorTestes.WinApp.ModuloMateria
{
    public partial class ListagemTarefasControl : UserControl
    {
        public ListagemTarefasControl()
        {
            InitializeComponent();
        }

        public void AtualizarRegistros(List<Materia> tarefas)
        {
            CarregarTarefas(tarefas);
        }

        public Materia ObtemTarefaSelecionada()
        {
            return (Materia)listTarefas.SelectedItem;
        }

        private void CarregarTarefas(List<Materia> tarefas)
        {
            listTarefas.Items.Clear();

            foreach (Materia t in tarefas)
            {
                listTarefas.Items.Add(t);
            }
        }
    }
}
