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

        public async Task<Chamado> AdicionarChamado(Chamado novoChamado)
        {
            await _context.Chamados.AddAsync(novoChamado);
            await _context.SaveChangesAsync();
            return novoChamado;
        }

        public async Task<List<Chamado>> BuscarChamados()
        {
            return await _context.Chamados.ToListAsync();
        }

        public async Task<Chamado> BuscarChamadoPorID(int id)
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

        public async Task<Result> DeletarChamado(int id)
        {
            Chamado chamado = await _context.Chamados.FirstOrDefaultAsync(chamad=> chamad.Id == id);

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
        public async Task<Result> AtualizarChamado(int id, Chamado novoChamado)
        {
            Chamado chamado = await _context.Chamados.FirstOrDefaultAsync(chamad => chamad.Id == id);

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
