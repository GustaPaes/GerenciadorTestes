using GerenciadorTestes.WinApp.Compartilhado;

namespace GerenciadorTestes.WinApp.ModuloMateria
{
    public class ConfiguracaoToolboxMateria : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Controle de Matéria";

        public override string TooltipInserir { get { return "Inserir uma nova matéria"; } }

        public override string TooltipEditar { get { return "Editar uma matéria existente"; } }

        public override string TooltipExcluir { get { return "Excluir uma matéria existente"; } }
    }
}
