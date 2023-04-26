using HelpDeskClean.Models;
using Microsoft.EntityFrameworkCore;

namespace HelpDeskClean.Data.Mappings
{
    public class LocalMap : IEntityTypeConfiguration<Local>
    {
        void IEntityTypeConfiguration<Local>.Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Local> builder)
        {
            builder.HasKey(l => l.Id);

            builder.Property(l => l.Descricao).IsRequired().HasMaxLength(100);
            builder.Property(l => l.Endereco).IsRequired().HasMaxLength(100);
            builder.Property(l => l.Cep).IsRequired().HasMaxLength(50);
            builder.Property(l => l.Estado).IsRequired().HasMaxLength(100);
            builder.Property(l => l.Cidade).IsRequired().HasMaxLength(100);         

        }
    }
}
