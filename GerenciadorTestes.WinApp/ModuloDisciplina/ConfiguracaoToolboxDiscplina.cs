using GerenciadorTestes.WinApp.Compartilhado;

namespace GerenciadorTestes.WinApp.ModuloDisciplina
{
    public class ConfiguracaoToolboxDiscplina : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cadastro de Contatos";

        public override string TooltipInserir { get { return "Inserir um novo contato"; } }

        public override string TooltipEditar { get { return "Editar um contato existente"; } }

        public override string TooltipExcluir { get { return "Excluir um contato existente"; } }

    }
}
