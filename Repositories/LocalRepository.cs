using FluentResults;
using HelpDeskClean.Data;
using HelpDeskClean.Models;
using HelpDeskClean.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HelpDeskClean.Repositories
{
    public class LocalRepository : ILocalRepository
    {
        private readonly ApplicationContext _context;

        public LocalRepository(ApplicationContext context)
        {
            _context = context;
        }
        //Adicionar repositorio
        async Task ILocalRepository.AdicionarLocal(Local novoLocal)
        {
            await _context.Locais.AddAsync(novoLocal);
            await _context.SaveChangesAsync();
        }

        //Get - buscar - repositorio
        async Task<List<Local>> ILocalRepository.BuscarLocais()
        {
            return await _context.Locais.ToListAsync();
        }

        //Get por Id - Buscar por id - repositorio
        async Task<Local> ILocalRepository.BuscarLocalPorID(int id)
        {
            Local localEncontrado = await _context.Locais.FirstOrDefaultAsync(local => local.Id == id);

            if (localEncontrado != null)
            {
                return localEncontrado;
            }
            else
            {
                return null;
            }
        }

        //Delete - repositorio
        public Result DeletarLocal(int id)
        {
            Local local = _context.Locais.FirstOrDefault(local => local.Id == id);

            if (local != null)
            {
                _context.Remove(local);
                _context.SaveChanges();
                return Result.Ok();
            }
            else
            {
                return Result.Fail("Erro");
            }
        }

        //Update - atualizar - repositorio
        Result ILocalRepository.AtualizarLocal(int id, Local novoLocal)
        {
            Local local = _context.Locais.FirstOrDefault(local => local.Id == id);

            if (novoLocal != null)
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
