using AgendaMedica.Dominio.Compartilhado;
using AgendaMedica.Dominio.ModuloAtividade;
using AgendaMedica.Dominio.ModuloMedico;
using AgendaMedica.Infra.Orm.ModuloAtividade;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace AgendaMedica.Infra.Orm.Compartilhado
{
    public class AgendaMedicaDbContext : DbContext, IContextoPersistencia
    {
        public AgendaMedicaDbContext(DbContextOptions options) : base(options) { }
        public async Task<bool> GravarAsync()
        {
            await SaveChangesAsync();
            return true;
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MapeadorMedicoOrm());
            modelBuilder.ApplyConfiguration(new MapeadorAtividadeOrm());

            var novoMedico = new Medico { Nome = "Dr. Teste I", CRM = "00000-AA", Email = "drteste1@example.com", Telefone = "123456789", Endereco = "Endereço do Dr. Teste I" };
            var novoMedico2 = new Medico { Nome = "Dr. Teste II", CRM = "09876-ZZ", Email = "drteste2@example.com", Telefone = "987654321", Endereco = "Endereço do Dr. Teste II" };
            var novoMedico3 = new Medico { Nome = "Dr. Teste III", CRM = "12345-AZ", Email = "drteste3@example.com", Telefone = "987654321", Endereco = "Endereço do Dr. Teste III" };

            modelBuilder.Entity<Medico>().HasData(novoMedico);
            modelBuilder.Entity<Medico>().HasData(novoMedico2);
            modelBuilder.Entity<Medico>().HasData(novoMedico3);
        }


        public async Task InicializarDadosDeTesteAsync()
        {
            if (!Set<Medico>().Any())
            {
                Set<Medico>().Add(new Medico { Nome = "Dr. Teste I", CRM = "00000-AA", Telefone = "123456789", Endereco = "Rua A", Email = "teste1@example.com" });
                Set<Medico>().Add(new Medico { Nome = "Dr. Teste II", CRM = "09876-ZZ", Telefone = "987654321", Endereco = "Rua B", Email = "teste2@example.com" });
                Set<Medico>().Add(new Medico { Nome = "Dr. Teste III", CRM = "12345-AZ", Telefone = "555555555", Endereco = "Rua C", Email = "teste3@example.com" });

                await SaveChangesAsync();
            }
        }

    }
}