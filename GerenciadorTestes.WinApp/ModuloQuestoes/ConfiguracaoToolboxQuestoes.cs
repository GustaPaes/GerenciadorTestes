using GerenciadorTestes.WinApp.Compartilhado;

namespace GerenciadorTestes.WinApp.ModuloQuestoes
{
    public class ConfiguracaoToolboxQuestoes : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Controle de Compromissos";

        public override string TooltipInserir => "Inserir um novo compromisso";

        public override string TooltipEditar => "Editar um compromisso existente";

        public override string TooltipExcluir => "Excluir um compromisso existente";

        public override string TooltipPdf => "Gerar um arquivo PDF";

        public override bool PdfHabilitado => true;
    }
}
