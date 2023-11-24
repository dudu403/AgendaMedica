using AgendaMedica.Dominio.ModuloAtividade;
using AgendaMedica.Dominio.ModuloMedico;
using Microsoft.EntityFrameworkCore;

namespace AgendaMedica.Infra.Orm.Compartilhado
{
    public class AgendaMedicaDbContext : DbContext
    {

        public DbSet<Medico> Medicos { get; set; }

        public DbSet<Atividade> Atividades { get; set; }

        public AgendaMedicaDbContext(DbContextOptions options) : base(options)
        {
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medico>();

            modelBuilder.Entity<Atividade>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
