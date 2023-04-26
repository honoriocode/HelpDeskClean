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
        public IActionResult AdicionarChamado([FromBody] Chamado chamado)
        {
            return CreatedAtAction(nameof(AdicionarChamado), new { id = chamado.Id }, chamado);
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
        public IActionResult DeletarChamado(int id)
        {
            Result respExcluir = _chamadoRepository.DeletarChamado(id);

            if (respExcluir.IsFailed)
                return NotFound();
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarChamado(int id, [FromBody] Chamado chamado)
        {
            Result respAtualizar = _chamadoRepository.AtualizarChamado(id, chamado);

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
