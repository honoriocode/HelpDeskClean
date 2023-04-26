using FluentResults;
using HelpDeskClean.Models;

namespace HelpDeskClean.Repositories.Interfaces
{
    public interface IChamadoRepository
    {
        Task<List<Chamado>> BuscarChamados();
        Task<Chamado> BuscarChamadoPorID(int id);
        Task AdicionarChamado(Chamado novoChamado);
        Result AtualizarChamado(int id, Chamado novoChamado);
        Result DeletarChamado(int id);
    }
}
