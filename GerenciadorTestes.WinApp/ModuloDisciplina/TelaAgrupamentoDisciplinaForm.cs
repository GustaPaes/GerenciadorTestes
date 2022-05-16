using GerenciadorTestes.Dominio.ModuloDisciplina;
using System.Windows.Forms;

namespace GerenciadorTestes.WinApp.ModuloDisciplina
{
    public partial class TelaAgrupamentoDisciplinaForm : Form
    {
        public TelaAgrupamentoDisciplinaForm()
        {
            InitializeComponent();
        }

        public AgrupamentoDisciplinaEnum TipoAgrupamento
        {
            get
            {
                if (rdbAgruparPorEmpresa.Checked)
                    return AgrupamentoDisciplinaEnum.AgruparPorEmpresa;

                else if (rdbAgruparPorCargo.Checked)
                    return AgrupamentoDisciplinaEnum.AgruparPorCargo;

                else
                    return AgrupamentoDisciplinaEnum.NaoAgrupar;
            }

        }
    }
}
