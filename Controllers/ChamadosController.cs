using FluentResults;
using HelpDeskClean.Models;
using HelpDeskClean.Repositories;
using HelpDeskClean.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HelpDeskClean.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChamadosController : ControllerBase
    {
        private readonly IChamadoRepository _chamadoRepository;
        public ChamadosController(IChamadoRepository chamadoRepository)
        {
            _chamadoRepository = chamadoRepository;
        }

        [HttpPost]
        public async Task<ActionResult> AdicionarChamado([FromBody] Chamado chamado)
        {
            await _chamadoRepository.AdicionarChamado(chamado);
            return CreatedAtAction(nameof(BuscarChamadoPorID), new { id = chamado.Id }, chamado);
        }

        [HttpGet]
        public async Task<ActionResult<List<Chamado>>> BuscarChamados()
        {
            List<Chamado> listaChamados = await _chamadoRepository.BuscarChamados();
            return listaChamados;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Chamado>> BuscarChamadoPorID(int id)
        {
            Chamado chamadoEncontrado = await _chamadoRepository.BuscarChamadoPorID(id);

            if (chamadoEncontrado != null)
            {
                return Ok(chamadoEncontrado);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("id")]
        public async Task<ActionResult<Result>> DeletarChamado(int id)
        {
            Result respExcluir = await _chamadoRepository.DeletarChamado(id);

            if (respExcluir.IsFailed)
                return NotFound();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Result>> AtualizarChamado(int id, [FromBody] Chamado chamado)
        {
            Result respAtualizar = await _chamadoRepository.AtualizarChamado(id, chamado);

            if (respAtualizar.IsFailed)
            {
                return NotFound();
            }
            else
            {
                return NoContent();
            }
        }

    }
}
