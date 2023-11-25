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
        public async Task<IActionResult> SelecionarTodos()
        {
            var medicos = await servicoMedico.SelecionarTodosAsync();

            var viewModel = mapeador.Map<List<ListarMedicoViewModel>> (medicos.Value);
            return Ok(viewModel);
        }

        [HttpGet("Vizualização-PorId/{id}")]
        public async Task<IActionResult> SelecionarPorId(Guid id)
        {
            var medicosResults = await servicoMedico.SelecionarPorIdAsync(id);

            if (medicosResults == null)
            {
                
                return NotFound();
            }

            var viewModel = mapeador.Map<VisualizarMedicoViewModel>(medicosResults.Value);
            return Ok(viewModel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Excluir(Guid id)
        {
            var exclusaoBemSucedida = await servicoMedico.ExcluirAsync(id);

            if (exclusaoBemSucedida)
            {
                return NoContent();
            }
            else
            {
                return NotFound(); 
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Editar(Guid id, [FromBody] EditarMedicoViewModel medicoViewModel)
        {
            if (medicoViewModel == null)
            {
                return BadRequest("Dados inválidos para edição");
            }

            var medicoExistenteResult = await servicoMedico.SelecionarPorIdAsync(id);

            if (medicoExistenteResult.IsFailed)
            {
                return NotFound();
            }

            var medicoExistente = medicoExistenteResult.Value;

            medicoExistente.Nome = medicoViewModel.Nome;
            medicoExistente.CRM = medicoViewModel.CRM;
            medicoExistente.telefone = medicoViewModel.telefone;
            medicoExistente.endereco = medicoViewModel.endereco;
            medicoExistente.email = medicoViewModel.email;

            var resultadoEdicao = await servicoMedico.EditarAsync(medicoExistente);

            if (resultadoEdicao.IsFailed)
            {
                return BadRequest(resultadoEdicao.Errors);
            }

            var viewModel = mapeador.Map<VisualizarMedicoViewModel>(resultadoEdicao.Value);
            return Ok(viewModel);
        }

    }
}