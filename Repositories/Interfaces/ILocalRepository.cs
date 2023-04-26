using FluentResults;
using HelpDeskClean.Models;

namespace HelpDeskClean.Repositories.Interfaces
{
    public interface ILocalRepository
    {
        Task<List<Local>> BuscarLocais();
        Task<Local> BuscarLocalPorID(int id);

        Task AdicionarLocal(Local novoLocal);
        Result AtualizarLocal(int id, Local novoLocal);
        Result DeletarLocal(int id);
    }
}
