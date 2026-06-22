using ListaDeTarefas.Data;
using ListaDeTarefas.Models;
using ListaDeTarefas.Service.Interfaces;
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
        private readonly ITarefaService _tarefaService;
        public TarefaController(AppDbContext context, ITarefaService tarefaService)
        {
            _context = context;
            _tarefaService = tarefaService;
        }

        [HttpGet("BuscarTodasTarefas")]
        public async Task<ActionResult<IEnumerable<TarefaModel>>> BuscarTodasTarefas()
        {
            var list = await _context.Tarefas.ToListAsync();
            return Ok(list);
        }

        [HttpGet("BuscarPorId/{id}")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            var Tarefa = await _tarefaService.BuscarPorId(id);

            if (Tarefa == null)
            {
                return NotFound("A Tarefa não foi Localizada");
            }
            return Ok(Tarefa);
        }

        [HttpPost("CriarTarefa")]
        public async Task<IActionResult> CriarTarefa(TarefaModel tarefa)
        {
            await _tarefaService.CreateAsync(tarefa);
            return CreatedAtAction(
                nameof(BuscarPorId),
                new { id = tarefa.Id },
                tarefa
                );
        }

        [HttpPut("AtualizarTarefa/{id}")]
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

        [HttpDelete("DeletarTarefa/{id}")]
        public async Task<IActionResult> DeletarTarefa(int id)
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







