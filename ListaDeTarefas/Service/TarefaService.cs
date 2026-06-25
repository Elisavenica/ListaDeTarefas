using Microsoft.EntityFrameworkCore;
using ListaDeTarefas.Models;
using ListaDeTarefas.Data;
using ListaDeTarefas.Service.Interfaces;
using ListaDeTarefas.Repositorio.Interfaces;

namespace ListaDeTarefas.Service
{
    public class TarefaService : ITarefaService
    {
        private readonly AppDbContext _context;
        private readonly ITarefaRepositorio _tarefaRepositorio;       

        public TarefaService(AppDbContext context, ITarefaRepositorio tarefaRepositorio)
        {
            _context = context;
            _tarefaRepositorio = tarefaRepositorio;
        }

        public async Task<TarefaModel?> BuscarPorId(int id)
        {
            return await _tarefaRepositorio.BuscarPorId(id);
        }

        public async Task<TarefaModel> CreateAsync(TarefaModel model)
        {
            await _tarefaRepositorio.CreateAsync(model);
            return model;
        }

        public async Task<TarefaModel> AtualizarTarefa(TarefaModel model)
        {
            return await _tarefaRepositorio.UpdateAsync(model);
        }

        public async Task DeleteAsync(int id)
        {
            await _context.Tarefas.Where(t => t.Id == id).ExecuteDeleteAsync();
        }

        public async Task<IEnumerable<TarefaModel>> GetAll()
        {
            return await _context.Tarefas.ToListAsync();
        }
    }
}