using ListaDeTarefas.Models;

namespace ListaDeTarefas.Service.Interfaces
{
    public interface ITarefaService
    {
        Task<IEnumerable<TarefaModel>> GetAll();
        Task<TarefaModel?> BuscarPorId(int id);
        Task<TarefaModel> CreateAsync(TarefaModel model);
        Task<TarefaModel> AtualizarTarefa(TarefaModel model);
        Task DeleteAsync(int id);
    }
}
