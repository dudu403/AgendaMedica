using AgendaMedica.Dominio.ModuloAtividade;

namespace AgendaMedica.WebApi.ViewModels
{

    public class FormsAtividadeViewModel
    {
        public DateTime Data { get; set; }
        public TimeSpan HorarioInicio { get; set; }
        public TimeSpan HorarioTermino { get; set; }
        public CategoriaEnum Categoria { get; set; }
        public List<Guid> MedicosId { get; set; }
    }
    public class InserirAtividadeViewModel : FormsAtividadeViewModel
    {

    }

    public class EditarAtividadeViewModel : FormsAtividadeViewModel
    {
  
    }

    public class ExcluirAtividadeViewModel
    {
        public Guid Id { get; set; }
    }

    public class ListarAtividadeViewModel
    {
        public Guid Id { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan HorarioInicio { get; set; }
        public TimeSpan HorarioTermino { get; set; }
        public CategoriaEnum Categoria { get; set; }
    }

    public class VisualizarAtividadeViewModel
    {
        public Guid Id { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan HorarioInicio { get; set; }
        public TimeSpan HorarioTermino { get; set; }
        public CategoriaEnum Categoria { get; set; }
        public List<ListarMedicoViewModel> Medicos { get; set; }
    }
}
