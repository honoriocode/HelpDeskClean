using FluentResults;
using HelpDeskClean.Data;
using HelpDeskClean.Models;
using HelpDeskClean.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HelpDeskClean.Repositories
{
    public class EquipamentoRepository : IEquipamentoRepository
    {
        private readonly ApplicationContext _context;

        public EquipamentoRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task AdicionarEquipamento(Equipamento novoEquipamento)
        {
            await _context.Equipamentos.AddAsync(novoEquipamento);
            await _context.SaveChangesAsync();
        }

        async Task<List<Equipamento>> IEquipamentoRepository.BuscarEquipamentos()
        {

            return await _context.Equipamentos.ToListAsync();
        }

        async Task<Equipamento> IEquipamentoRepository.BuscarEquipamentoID(int id)
        {
            Equipamento equipamentoEncontrado = await _context.Equipamentos.FirstOrDefaultAsync(equip => equip.Id == id);

            if (equipamentoEncontrado != null)
            {
                return equipamentoEncontrado;
            }
            else
            {
                return null;
            }
        }

        public Result DeletarEquipamento(int id)
        {
            Equipamento equipamento = _context.Equipamentos.FirstOrDefault(equip => equip.Id == id);

            if (equipamento != null)
            {
                _context.Remove(equipamento);
                _context.SaveChanges();
                return Result.Ok();
            }
            else
            {
                return Result.Fail("Erro");
            }
        }

        Result IEquipamentoRepository.AtualizarEquipamento(int id, Equipamento novoEquipamento)
        {
            Equipamento equipamento = _context.Equipamentos.FirstOrDefault(equip => equip.Id == id);

            if (novoEquipamento != null)
            {
                _context.SaveChanges();
                return Result.Ok();
            }
            else
            {
                return Result.Fail("erro");
            }
        }

    }
}
