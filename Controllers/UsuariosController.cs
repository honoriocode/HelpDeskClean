using FluentResults;
using HelpDeskClean.Models;
using HelpDeskClean.Repositories;
using HelpDeskClean.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HelpDeskClean.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {

        private readonly IUsuarioRepository _usuarioRepository;
        public UsuariosController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarUsuario([FromBody] Usuario usuario)
        {
            await _usuarioRepository.AdicionarUsuario(usuario);
            return CreatedAtAction(nameof(BuscarUsuarioPorID), new { id = usuario.Id }, usuario);
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> BuscarUsuarios()
        {
            List<Usuario> listaUsuarios = await _usuarioRepository.BuscarUsuarios();
            return listaUsuarios;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> BuscarUsuarioPorID(int id)
        {
            Usuario usuarioEncontrado = await _usuarioRepository.BuscarUsuarioPorID(id);

            if (usuarioEncontrado != null)
            {
                return Ok(usuarioEncontrado);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("id")]
        public IActionResult DeletarUsuario(int id)
        {
            Result respExcluir = _usuarioRepository.DeletarUsuario(id);

            if (respExcluir.IsFailed)
                return NotFound();
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarUsuario(int id, [FromBody] Usuario usuario)
        {
            Result respAtualizar = _usuarioRepository.AtualizarUsuario(id, usuario);

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
