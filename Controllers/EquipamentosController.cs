using FluentResults;
using HelpDeskClean.Models;
using HelpDeskClean.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HelpDeskClean.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipamentosController : ControllerBase
    {
        private readonly IEquipamentoRepository _equipamentoRepository;
        public EquipamentosController(IEquipamentoRepository equipamentoRepository)
        {
            _equipamentoRepository = equipamentoRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarEquipamento([FromBody] Equipamento equipamento)
        {
            await _equipamentoRepository.AdicionarEquipamento(equipamento);
            return CreatedAtAction(nameof(BuscarEquipamentoID), new { id = equipamento.Id }, equipamento);
        }

        [HttpGet]
        public async Task <ActionResult <List<Equipamento>>> BuscarEquipamentos()
        {
            List<Equipamento> listaEquipamentos = await _equipamentoRepository.BuscarEquipamentos();
            return listaEquipamentos;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Equipamento>> BuscarEquipamentoID(int id)
        {
            Equipamento equipamentoEncontrado = await _equipamentoRepository.BuscarEquipamentoID(id);

            if (equipamentoEncontrado != null)
            {
                return Ok(equipamentoEncontrado);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("id")]
        public IActionResult DeletarEquipamento(int id)
        {
            Result respExcluir = _equipamentoRepository.DeletarEquipamento(id);

            if (respExcluir.IsFailed)
                return NotFound();
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarEquipamento (int id, [FromBody]  Equipamento equipamento)
        {
            Result respAtualizar = _equipamentoRepository.AtualizarEquipamento(id, equipamento);

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
