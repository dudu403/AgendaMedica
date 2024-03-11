using AgendaMedica.Dominio.ModuloMedico;
using AgendaMedica.WebApi.ViewModels;
using AutoMapper;

namespace EAgendaMedica.WebApi.Config.AutoMapperProfiles
{
    public class MedicoProfile : Profile
    {
        public MedicoProfile()
        {
            CreateMap<Medico, ListarMedicoViewModel>();
            CreateMap<Medico, VisualizarMedicoViewModel>();

            CreateMap<InserirMedicoViewModel, Medico>();
            CreateMap<EditarMedicoViewModel, Medico>();
        }
    }
}