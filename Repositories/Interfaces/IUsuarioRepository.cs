using FluentResults;
using HelpDeskClean.Models;

namespace HelpDeskClean.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> BuscarUsuarios();
        Task<Usuario> BuscarUsuarioPorID(int id);
        Task AdicionarUsuario(Usuario novoUsuario);

        Result AtualizarUsuario(int id, Usuario Usuario);
        Result DeletarUsuario(int id);
    }

}
