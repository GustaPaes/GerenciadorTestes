using GerenciadorTestes.Dominio.ModuloTeste;
using System.Windows.Forms;

namespace GerenciadorTestes.WinApp.ModuloTeste
{
    public partial class TelaAgrupamentoTesteForm : Form
    {
        public TelaAgrupamentoTesteForm()
        {
            InitializeComponent();
        }

        public AgrupamentoTesteEnum TipoAgrupamento
        {
            get
            {
                if (rdbAgruparPorEmpresa.Checked)
                    return AgrupamentoTesteEnum.AgruparPorEmpresa;

                else if (rdbAgruparPorCargo.Checked)
                    return AgrupamentoTesteEnum.AgruparPorCargo;

                else
                    return AgrupamentoTesteEnum.NaoAgrupar;
            }

        }
    }
}
