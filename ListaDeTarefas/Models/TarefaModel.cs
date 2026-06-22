namespace ListaDeTarefas.Models
{
    public class TarefaModel
    {
        public int Id { get; set; }
        public required string Titulo { get; set; }
        public bool Concluido { get; set; }
        public string Status { get; set; }
        public DateTime DataCriacao { get; set; }

    }
}
