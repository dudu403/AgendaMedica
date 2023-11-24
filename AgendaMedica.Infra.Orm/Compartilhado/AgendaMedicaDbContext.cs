using AgendaMedica.Dominio.ModuloAtividade;
using AgendaMedica.Dominio.ModuloMedico;
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
            modelBuilder.Entity<Medico>(model =>
            {
                model.Property(x => x.Id).ValueGeneratedNever();
                model.Property(x => x.Nome).IsRequired();
                model.Property(x => x.CRM).IsRequired();
                model.Property(x => x.telefone).IsRequired();
                model.Property(x => x.endereco).IsRequired();
                model.Property(x => x.email).IsRequired();

            });

            modelBuilder.Entity<Atividade>(model =>
            {
                model.Property(x => x.Id).ValueGeneratedNever();
                //model.Property(x => x.Medico).ValueGeneratedNever();
                model.Property(x => x.Data).ValueGeneratedNever();
                model.Property(x => x.HorarioInicio).ValueGeneratedNever();
                model.Property(x => x.HorarioTernino).ValueGeneratedNever();
                model.Property(x => x.Categoria).HasConversion<int>();
                model.HasOne(x => x.Medico).WithMany().HasForeignKey(x => x.MedicoID)
                .HasConstraintName("FK_TBMedico_TBAtividade").OnDelete(DeleteBehavior.NoAction);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
