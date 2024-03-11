using AgendaMedica.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EAgendaMedica.Infra.Orm.Compartilhado
{
    public class EAgendaDbContextFactory : IDesignTimeDbContextFactory<AgendaMedicaDbContext>
    {
        public AgendaMedicaDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AgendaMedicaDbContext>();

            builder.UseSqlServer(@"Data Source=(LOCALDB)\MSSQLLOCALDB;Initial Catalog=EAgendaMedica;Integrated Security=True");

            return new AgendaMedicaDbContext(builder.Options);
        }
    }
}