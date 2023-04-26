using FluentResults;
using HelpDeskClean.Models;
using HelpDeskClean.Repositories;
using HelpDeskClean.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HelpDeskClean.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocaisController : ControllerBase
    {
        private readonly ILocalRepository _localRepository;
        public LocaisController(ILocalRepository localRepository)
        {
            _localRepository = localRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarLocal([FromBody] Local local)
        {
            await _localRepository.AdicionarLocal(local);
            return CreatedAtAction(nameof(BuscarLocalPorID), new { id = local.Id }, local);
        }

        [HttpGet]
        public async Task<ActionResult<List<Local>>> BuscarLocais()
        {
            List<Local> listaLocais = await _localRepository.BuscarLocais();
            return listaLocais;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Local>> BuscarLocalPorID(int id)
        {
            Local localEncontrado = await _localRepository.BuscarLocalPorID(id);

            if (localEncontrado != null)
            {
                return Ok(localEncontrado);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("id")]
        public IActionResult DeletarLocal(int id)
        {
            Result respExcluir = _localRepository.DeletarLocal(id);

            if (respExcluir.IsFailed)
                return NotFound();
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarLocal(int id, [FromBody] Local local)
        {
            Result respAtualizar = _localRepository.AtualizarLocal(id, local);

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
