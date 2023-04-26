using FluentResults;
using HelpDeskClean.Models;

namespace HelpDeskClean.Repositories.Interfaces
{
    public interface IEquipamentoRepository
    {
        Task<List<Equipamento>> BuscarEquipamentos();
        Task<Equipamento> BuscarEquipamentoID(int id);
        Task AdicionarEquipamento(Equipamento novoEquipamento);
        Result AtualizarEquipamento(int id, Equipamento novoEquipamento);
        Result DeletarEquipamento(int id);

    }
}
