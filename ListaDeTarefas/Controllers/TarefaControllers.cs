using ListaDeTarefas.Data;
using ListaDeTarefas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace ListaDeTarefas.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {

        private readonly AppDbContext _context;
        public TarefaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TarefaModel>>> GetAll()
        {
            var list = await _context.Tarefas.ToListAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Tarefa = await _context.Tarefas.FindAsync(id);
            if (Tarefa == null)
            {
                return NotFound("A Tarefa não foi Localizada");
            }
            return Ok(Tarefa);
        }
        [HttpPost]
        public async Task<IActionResult> Criar(TarefaModel tarefa)
        {
            _context.Tarefas.Add(tarefa);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetById),
                new { id = tarefa.Id },
                tarefa
                );
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarTarefa(int id, TarefaModel tarefa)
        {
            var tarefaExistente = await _context.Tarefas.FindAsync(id);

            if (tarefaExistente == null)
            {
                return NotFound("Tarefa não encontrada");
            }
            tarefaExistente.Titulo = tarefa.Titulo;
            tarefaExistente.Concluido = tarefa.Concluido;
            tarefaExistente.DataCriacao = tarefa.DataCriacao;

            await _context.SaveChangesAsync();

            return Ok(tarefaExistente);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);
            if (tarefa == null)

                return NotFound(new { mensagem = "Tarefa Inválida." });
            _context.Tarefas.Remove(tarefa);
            await _context.SaveChangesAsync();
            return Ok(tarefa);



        }
    }

}







