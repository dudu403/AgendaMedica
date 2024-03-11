namespace AgendaMedica.WebApi.ViewModels
{
    public class InserirMedicoViewModel
    {
        public string Nome { get; set; }
        public string CRM { get; set; }
        public string telefone { get; set; }
        public string endereco { get; set; }
        public string email { get; set; }
    }

    public class EditarMedicoViewModel
    {
        public string Nome { get; set; }
        public string CRM { get; set; }
        public string telefone { get; set; }
        public string endereco { get; set; }
        public string email { get; set; }
    }

    public class ExcluirMedicoViewModel
    {
        public Guid Id { get; set; }
    }


    public class ListarMedicoViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CRM { get; set; }
        public string telefone { get; set; }
        public string endereco { get; set; }
        public string email { get; set; }
    }

    public class VisualizarMedicoViewModel
    {
        public string Nome { get; set; }
        public string CRM { get; set; }
        public string telefone { get; set; }
        public string endereco { get; set; }
        public string email { get; set; }
        public List<ListarAtividadeViewModel> Atividades { get; set; }
    }
}
