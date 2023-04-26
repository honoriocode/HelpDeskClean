using HelpDeskClean.Models;
using Microsoft.EntityFrameworkCore;

namespace HelpDeskClean.Data.Mappings
{
    public class ChamadoMap : IEntityTypeConfiguration<Chamado>
    {
        void IEntityTypeConfiguration<Chamado>.Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Chamado> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Descricao).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Usuario).IsRequired().HasMaxLength(100);
            builder.Property(c => c.DataAbertura).IsRequired();
            builder.Property(c => c.DataEncerramento).IsRequired();
            builder.Property(c => c.SubstituidoPor).IsRequired().HasMaxLength(100);
            builder.Property(c => c.LocalAnterior).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Equipamentos).IsRequired().HasMaxLength(100);
            builder.Property(c => c.QualTecnico).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Solucao).IsRequired().HasMaxLength(100);
        }

    }
}
