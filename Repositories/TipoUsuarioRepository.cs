using FluentResults;
using HelpDeskClean.Data;
using HelpDeskClean.Models;
using HelpDeskClean.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HelpDeskClean.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private readonly ApplicationContext _context;

        public TipoUsuarioRepository(ApplicationContext context)
        {
            _context = context;
        }             

        //Adicionar repositorio
        async Task ITipoUsuarioRepository.AdicionarTipoUsuario(TipoUsuario novoTipoUsuario)
        {
            await _context.TiposUsuarios.AddAsync(novoTipoUsuario);
            await _context.SaveChangesAsync();
        }

        //Get - buscar - repositorio
        async Task<List<TipoUsuario>> ITipoUsuarioRepository.BuscarTipoUsuario()
        {
            return await _context.TiposUsuarios.ToListAsync();
        }

        //Get por Id - Buscar por id - repositorio
        async Task<TipoUsuario> ITipoUsuarioRepository.BuscarTipoUsuarioPorID(int id)
        {
            TipoUsuario tipoUsuarioEncontrado = await _context.TiposUsuarios.FirstOrDefaultAsync(typeuser => typeuser.Id == id);

            if (tipoUsuarioEncontrado != null)
            {
                return tipoUsuarioEncontrado;
            }
            else
            {
                return null;
            }
        }

        //Delete - repositorio
        public Result DeletarTipoUsuario(int id)
        {
            TipoUsuario tipoUsuario = _context.TiposUsuarios.FirstOrDefault(typeuser => typeuser.Id == id);

            if (tipoUsuario != null)
            {
                _context.Remove(tipoUsuario);
                _context.SaveChanges();
                return Result.Ok();
            }
            else
            {
                return Result.Fail("Erro");
            }
        }

        //Update - atualizar - repositorio
        Result ITipoUsuarioRepository.AtualizarTipoUsuario(int id, TipoUsuario novoTipoUsuario)
        {
            TipoUsuario tipoUsuario = _context.TiposUsuarios.FirstOrDefault(typeuser => typeuser.Id == id);

            if (novoTipoUsuario != null)
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
