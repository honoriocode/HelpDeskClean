using FluentResults;
using HelpDeskClean.Models;

namespace HelpDeskClean.Repositories.Interfaces
{
    public interface ITipoUsuarioRepository
    {
        Task<List<TipoUsuario>> BuscarTipoUsuario();
        Task<TipoUsuario> BuscarTipoUsuarioPorID(int id);
        Task AdicionarTipoUsuario(TipoUsuario novoTipoUsuario);
        Result AtualizarTipoUsuario(int id, TipoUsuario tipoUsuario);
        Result DeletarTipoUsuario(int id);
    }
}
