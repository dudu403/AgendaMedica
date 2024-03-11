using AgendaMedica.Dominio.ModuloAtividade;
using AgendaMedica.Dominio.ModuloMedico;
using AgendaMedica.WebApi.ViewModels;
using AutoMapper;

namespace EAgendaMedica.WebApi.Config.AutoMapperProfiles
{
    public class AtividadeProfile : Profile
    {
        public AtividadeProfile()
        {
            CreateMap<Atividade, ListarAtividadeViewModel>();
            CreateMap<Atividade, VisualizarAtividadeViewModel>();

            CreateMap<FormsAtividadeViewModel, Atividade>().ForMember(destino => destino.Medicos, opt => opt.Ignore()).AfterMap<ConfigurarMedicoMappingAction>();
        }
    }

    public class ConfigurarMedicoMappingAction : IMappingAction<FormsAtividadeViewModel, Atividade>
    {
        private readonly IRepositorioMedico repositorioMedico;

        public ConfigurarMedicoMappingAction(IRepositorioMedico repositorioMedico)
        {
            this.repositorioMedico = repositorioMedico;
        }

        public void Process(FormsAtividadeViewModel viewModel, Atividade atividade, ResolutionContext context)
        {
            atividade.Medicos.Clear();
            foreach (Guid id in viewModel.MedicosId)
                atividade.Medicos.Add(repositorioMedico.SelecionarPorId(id));
        }
    }
}