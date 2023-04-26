using HelpDeskClean.Data.Mappings;
using HelpDeskClean.Models;
using Microsoft.EntityFrameworkCore;

namespace HelpDeskClean.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        { }

        public DbSet<Equipamento> Equipamentos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Chamado> Chamados { get; set; }
        public DbSet<Local> Locais { get; set; }
        public DbSet<TipoUsuario> TiposUsuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EquipamentoMap());
            base.OnModelCreating(modelBuilder);
        }

    }
}
