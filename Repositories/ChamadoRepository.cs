using FluentResults;
using HelpDeskClean.Data;
using HelpDeskClean.Models;
using HelpDeskClean.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HelpDeskClean.Repositories
{
    public class ChamadoRepository : IChamadoRepository
    {
        private readonly ApplicationContext _context;

        public ChamadoRepository(ApplicationContext context)
        {
            _context = context;
        }

        async Task IChamadoRepository.AdicionarChamado(Chamado novoChamado)
        {
            await _context.Chamados.AddAsync(novoChamado);
            await _context.SaveChangesAsync();
        }

        async Task<List<Chamado>> IChamadoRepository.BuscarChamados()
        {
            return await _context.Chamados.ToListAsync();
        }

        async Task<Chamado> IChamadoRepository.BuscarChamadoPorID(int id)
        {
            Chamado chamadoEncontrado = await _context.Chamados.FirstOrDefaultAsync(chamad => chamad.Id == id);

            if (chamadoEncontrado != null)
            {
                return chamadoEncontrado;
            }
            else
            {
                return null;
            }
        }

        public Result DeletarChamado(int id)
        {
            Chamado chamado = _context.Chamados.FirstOrDefault(chamad=> chamad.Id == id);

            if (chamado != null)
            {
                _context.Remove(chamado);
                _context.SaveChanges();
                return Result.Ok();
            }
            else
            {
                return Result.Fail("Erro");
            }
        }
        Result IChamadoRepository.AtualizarChamado(int id, Chamado novoChamado)
        {
            Chamado chamado = _context.Chamados.FirstOrDefault(chamad => chamad.Id == id);

            if (chamado != null)
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
