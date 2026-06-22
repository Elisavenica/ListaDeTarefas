using ListaDeTarefas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ListaDeTarefas.ConfigureMap
{
    public class TarefaMap : IEntityTypeConfiguration<TarefaModel>
    {
        public void Configure(EntityTypeBuilder<TarefaModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Titulo).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Concluido).IsRequired();
            builder.Property(x => x.DataCriacao).IsRequired();
            builder.Property(x => x.Status).IsRequired();
        }
    }
}
