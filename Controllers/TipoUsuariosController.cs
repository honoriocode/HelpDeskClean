using FluentResults;
using HelpDeskClean.Models;
using HelpDeskClean.Repositories;
using HelpDeskClean.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HelpDeskClean.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUsuariosController : ControllerBase
    {
        private readonly ITipoUsuarioRepository _tipoUsuarioRepository;
        public TipoUsuariosController(ITipoUsuarioRepository tipoUsuarioRepository)
        {
            _tipoUsuarioRepository = tipoUsuarioRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarTipoUsuario([FromBody] TipoUsuario tipoUsuario)
        {
            await _tipoUsuarioRepository.AdicionarTipoUsuario(tipoUsuario);
            return CreatedAtAction(nameof(BuscarTipoUsuarioPorID), new { id = tipoUsuario.Id }, tipoUsuario);
        }

        [HttpGet]
        public async Task<ActionResult<List<TipoUsuario>>> BuscarTipoUsuario()
        {
            List<TipoUsuario> listaTiposUsuarios = await _tipoUsuarioRepository.BuscarTipoUsuario();
            return listaTiposUsuarios;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TipoUsuario>> BuscarTipoUsuarioPorID(int id)
        {
            TipoUsuario tipoUsuarioEncontrado = await _tipoUsuarioRepository.BuscarTipoUsuarioPorID(id);

            if (tipoUsuarioEncontrado != null)
            {
                return Ok(tipoUsuarioEncontrado);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("id")]
        public IActionResult DeletarTipoUsuario(int id)
        {
            Result respExcluir = _tipoUsuarioRepository.DeletarTipoUsuario(id);

            if (respExcluir.IsFailed)
                return NotFound();
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarTipoUsuario(int id, [FromBody] TipoUsuario tipoUsuario)
        {
            Result respAtualizar = _tipoUsuarioRepository.AtualizarTipoUsuario(id, tipoUsuario);

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
