using GerenciadorTestes.Dominio.ModuloDisciplina;
using FluentValidation.Results;
using System;
using System.Windows.Forms;

namespace GerenciadorTestes.WinApp.ModuloDisciplina
{
    public partial class TelaCadastroDisciplinasForm : Form
    {
        public TelaCadastroDisciplinasForm()
        {
            InitializeComponent();
        }

        private Disciplina contato;

        public Func<Disciplina, ValidationResult> GravarRegistro { get; set; }

        public Disciplina Disciplina
        {
            get { return contato; }
            set
            {
                contato = value;

                txtNumero.Text = contato.Numero.ToString();
                txtNome.Text = contato.Nome;
            }
        }

        private void btnGravar_Click(object sender, System.EventArgs e)
        {
            contato.Nome = txtNome.Text;

            var resultadoValidacao = GravarRegistro(contato);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }

        private void TelaCadastroContatosForm_Load(object sender, EventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
        }

        private void TelaCadastroContatosForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
        }
    }
}
