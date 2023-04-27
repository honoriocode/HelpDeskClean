using FluentResults;
using HelpDeskClean.Models;

namespace HelpDeskClean.Repositories.Interfaces
{
    public interface IEquipamentoRepository
    {
        Task<List<Equipamento>> BuscarEquipamentos();
        Task<Equipamento> BuscarEquipamentoID(int id);
        Task<Equipamento> AdicionarEquipamento(Equipamento novoEquipamento);
        Task<Result> AtualizarEquipamento(int id, Equipamento novoEquipamento);
        Task<Result> DeletarEquipamento(int id);

    }
}
