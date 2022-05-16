using GerenciadorTestes.Dominio.ModuloQuestoes;
using GerenciadorTestes.Dominio.ModuloDisciplina;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GerenciadorTestes.Dominio.ModuloMateria;

namespace GerenciadorTestes.WinApp.ModuloQuestoes
{
    public partial class TelaCadastroQuestoesForm : Form
    {
        private Questao questao;

        public TelaCadastroQuestoesForm(List<Disciplina> disciplina, List<Materia> materia)
        {
            InitializeComponent();

            CarregarDisciplinas(disciplina);
            CarregarMaterias(materia);
        }


        private void CarregarDisciplinas(List<Disciplina> disciplinas)
        {
            cmbDisciplina.Items.Clear();

            foreach (var item in disciplinas)
            {
                cmbDisciplina.Items.Add(item);
            }
        }

        private void CarregarMaterias(List<Materia> materias)
        {
            cmbMateria.Items.Clear();

            foreach (var item in materias)
            {
                cmbMateria.Items.Add(item);
            }
        }

        public Func<Questao, ValidationResult> GravarRegistro { get; set; }

        public Questao Questao
        {
            get { return questao; }
            set
            {
                questao = value;

                txtNumero.Text = questao.Numero.ToString();

                txtEnunciado.Text = questao.Enunciado;
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            questao.Enunciado = txtEnunciado.Text;
            questao.Disciplinas = (Disciplina)cmbDisciplina.SelectedItem;
            questao.Materias = (Materia)cmbDisciplina.SelectedItem;
         
            var resultadoValidacao = GravarRegistro(questao);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }

        private void TelaCadastroCompromissosForm_Load(object sender, EventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
        }

        private void TelaCadastroCompromisssosForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
        }
    }
}
