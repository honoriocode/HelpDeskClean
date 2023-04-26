using HelpDeskClean.Models;
using Microsoft.EntityFrameworkCore;

namespace HelpDeskClean.Data.Mappings
{
    public class EquipamentoMap : IEntityTypeConfiguration<Equipamento>
    {
        void IEntityTypeConfiguration<Equipamento>.Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Equipamento> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.NumeroSerie).IsRequired();
            builder.Property(e => e.DataEmissao).IsRequired();
            builder.Property(e => e.Fornecedor).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Cnpj).IsRequired();
            builder.Property(e => e.Data).IsRequired();
            builder.Property(e => e.Marca).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Memoria).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Hd).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Processador).IsRequired().HasMaxLength(100);

        }
    }
}
