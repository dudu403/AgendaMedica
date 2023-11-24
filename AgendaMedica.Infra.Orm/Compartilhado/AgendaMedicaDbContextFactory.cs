using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaMedica.Infra.Orm.Compartilhado
{
    public class AgendaMedicaDbContextFactory : IDesignTimeDbContextFactory<AgendaMedicaDbContext>
    {
        public AgendaMedicaDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AgendaMedicaDbContext>();

            IConfiguration configuracao = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json")
              .Build();

            var connectionString = configuracao.GetConnectionString("SqlServer");

            optionsBuilder.UseSqlServer(connectionString);

            var dbContext = new AgendaMedicaDbContext(optionsBuilder.Options);

            dbContext.SaveChanges();

            return dbContext;
        }
    }
}
