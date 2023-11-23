using AgendaMedica.Dominio.ModuloAtividade;
using AgendaMedica.Dominio.ModuloMedico;
using Microsoft.EntityFrameworkCore;

namespace AgendaMedica.Infra.Orm.Compartilhado
{
    public class AgendaMedicaDbContext : DbContext
    {

        public AgendaMedicaDbContext(DbContextOptions<AgendaMedicaDbContext> options)
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
