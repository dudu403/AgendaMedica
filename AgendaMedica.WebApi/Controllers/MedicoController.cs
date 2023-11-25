using AgendaMedica.Aplicacao.ModuloMedico;
using AgendaMedica.WebApi.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AgendaMedica.WebApi.Controllers
{
    [ApiController]
    [Route("api/medicos")]
    public class MedicoController : ControllerBase
    {
        private readonly ServicoMedico servicoMedico;
        private readonly IMapper mapeador;

        public MedicoController(ServicoMedico servicoMedico, IMapper mapeador) 
        {
            this.servicoMedico = servicoMedico;
            this.mapeador = mapeador;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var medicos = await servicoMedico.SelecionarTodosAsync();

            var viewModel = mapeador.Map<List<ListarMedicoViewModel>> (medicos.Value);
            return Ok(viewModel);
        }
    }   
}