using FluentResults;
using HelpDeskClean.Data;
using HelpDeskClean.Models;
using HelpDeskClean.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HelpDeskClean.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationContext _context;

        public UsuarioRepository(ApplicationContext context)
        {
            _context = context;
        }

        //Adicionar repositorio
        async Task IUsuarioRepository.AdicionarUsuario(Usuario novoUsuario)
        {
            await _context.Usuarios.AddAsync(novoUsuario);
            await _context.SaveChangesAsync();
        }

        //Get - buscar - repositorio
        async Task<List<Usuario>> IUsuarioRepository.BuscarUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        //Get por Id - Buscar por id - repositorio
        async Task<Usuario> IUsuarioRepository.BuscarUsuarioPorID(int id)
        {
            Usuario UsuarioEncontrado = await _context.Usuarios.FirstOrDefaultAsync(user => user.Id == id);

            if (UsuarioEncontrado != null)
            {
                return UsuarioEncontrado;
            }
            else
            {
                return null;
            }
        }

        //Delete - repositorio
        public Result DeletarUsuario(int id)
        {
            Usuario Usuario = _context.Usuarios.FirstOrDefault(user => user.Id == id);

            if (Usuario != null)
            {
                _context.Remove(Usuario);
                _context.SaveChanges();
                return Result.Ok();
            }
            else
            {
                return Result.Fail("Erro");
            }
        }

        Result IUsuarioRepository.AtualizarUsuario(int id, Usuario novoUsuario)
        {
            Usuario Usuario = _context.Usuarios.FirstOrDefault(user => user.Id == id);

            if (novoUsuario != null)
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
