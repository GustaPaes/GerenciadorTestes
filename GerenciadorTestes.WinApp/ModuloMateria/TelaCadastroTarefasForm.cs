using GerenciadorTestes.Dominio.ModuloMateria;
using FluentValidation.Results;
using System;
using System.Windows.Forms;
using GerenciadorTestes.Dominio.ModuloDisciplina;

namespace GerenciadorTestes.WinApp.ModuloMateria
{
    public partial class TelaCadastroMateriasForm : Form // View
    {
        private Materia materia;

        public TelaCadastroMateriasForm()
        {
            InitializeComponent();
        }

        public Func<Materia, ValidationResult> GravarRegistro { get; set; }

        public Materia Materia
        {
            get
            {
                return materia;
            }
            set
            {
                materia = value;
                txtNumero.Text = materia.Numero.ToString();
                txtNome.Text = materia.Nome;
                txtSerie.Text = materia.Serie;
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            materia.Nome = txtNome.Text;
            materia.Disciplina = (Disciplina)cmbDisciplina.SelectedItem;
            materia.Serie = txtSerie.Text;

            var resultadoValidacao = GravarRegistro(materia);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }

        private void TelaCadastroMateriasForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
        }

        private void TelaCadastroMateriasForm_Load(object sender, EventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
        }
    }
}
