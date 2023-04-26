using HelpDeskClean.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpDeskClean.Data.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        void IEntityTypeConfiguration<Usuario>.Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<HelpDeskClean.Models.Usuario> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Nome).IsRequired();
            builder.Property(u => u.Login).IsRequired().HasMaxLength(50);
            builder.Property(u => u.Senha).IsRequired().HasMaxLength(50);
            builder.Property(u => u.CriadoEm).IsRequired();
            builder.Property(u => u.AtualizadoEm).IsRequired();
            builder.Property(u => u.Status).IsRequired();
            builder.Property(u => u.Contato).IsRequired().HasMaxLength(100);

        }
    }
}
