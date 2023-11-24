using AgendaMedica.Dominio.ModuloAtividade;
using AgendaMedica.Dominio.ModuloMedico;
using AgendaMedica.Infra.Orm.ModuloAtividade;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

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
            modelBuilder.ApplyConfiguration(new MapeadorMedicoOrm());

            modelBuilder.ApplyConfiguration(new MapeadorAtividadeOrm());

            base.OnModelCreating(modelBuilder);
        }
    }
}
