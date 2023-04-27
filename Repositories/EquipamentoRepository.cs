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

        public async Task<Equipamento> AdicionarEquipamento(Equipamento novoEquipamento)
        {
            await _context.Equipamentos.AddAsync(novoEquipamento);
            await _context.SaveChangesAsync();
            return novoEquipamento;
        }

        public async Task<List<Equipamento>> BuscarEquipamentos()
        {

            return await _context.Equipamentos.ToListAsync();
        }

        public async Task<Equipamento> BuscarEquipamentoID(int id)
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

        public async Task<Result> DeletarEquipamento(int id)
        {
            Equipamento equipamento = await _context.Equipamentos.FirstOrDefaultAsync(equip => equip.Id == id);

            if (equipamento != null)
            {
                _context.Remove(equipamento);
                await _context.SaveChangesAsync();
                return Result.Ok();
            }
            else
            {
                return Result.Fail("Erro");
            }
        }

        public async Task<Result> AtualizarEquipamento(int id, Equipamento novoEquipamento)
        {
            Equipamento equipamento = await _context.Equipamentos.FirstOrDefaultAsync(equip => equip.Id == id);

            if (novoEquipamento != null)
            {
                await _context.SaveChangesAsync();
                return Result.Ok();
            }
            else
            {
                return Result.Fail("erro");
            }
        }

    }
}
