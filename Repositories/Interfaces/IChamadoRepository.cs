using FluentResults;
using HelpDeskClean.Models;

namespace HelpDeskClean.Repositories.Interfaces
{
    public interface IChamadoRepository
    {
        Task<List<Chamado>> BuscarChamados();
        Task<Chamado> BuscarChamadoPorID(int id);
        Task<Chamado> AdicionarChamado(Chamado novoChamado);
        Task<Result> AtualizarChamado(int id, Chamado novoChamado);
        Task<Result> DeletarChamado(int id);
    }
}
