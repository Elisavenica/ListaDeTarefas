using ListaDeTarefas.Models;

namespace ListaDeTarefas.Repositorio.Interfaces
{
    public interface ITarefaRepositorio
    {
        Task<IEnumerable<TarefaModel>> GetAll();
        Task<TarefaModel?> GetById(int id);
        Task<TarefaModel> CreateAsync(TarefaModel model);
        Task<TarefaModel> UpdateAsync(TarefaModel model);
        Task DeleteAsync (int id);
    }
}
