using ListaDeTarefas.Data;
using ListaDeTarefas.Models;
using ListaDeTarefas.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ListaDeTarefas.Repositorio
{
    public class TarefaRepositorio : ITarefaRepositorio
    {
       
        private readonly AppDbContext _context;

        public TarefaRepositorio(AppDbContext context)
        {
            _context = context;
          
        }

        public async Task<TarefaModel?> BuscarPorId(int id)
        {
            return await _context.Tarefas.FindAsync(id);
        }

        public async Task<TarefaModel> CreateAsync(TarefaModel model)
        {
            await _context.Tarefas.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }
        public async Task<TarefaModel> UpdateAsync(TarefaModel model)
        {
            _context.Tarefas.Update(model);
            await _context.SaveChangesAsync();
            return model;
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
