using AgendaMedica.Dominio.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace AgendaMedica.Infra.Orm.Compartilhado
{
    
    public class RepositorioBase<TEntidade> where TEntidade : Entidade
    {
        protected AgendaMedicaDbContext dbContext;
        protected DbSet<TEntidade> registros;

        public RepositorioBase(IContextoPersistencia ctx)
        {
            this.dbContext = (AgendaMedicaDbContext)dbContext;
            this.registros = dbContext.Set<TEntidade>();
        }

        public async Task<bool> InserirAsync(TEntidade registro)
        {
            await registros.AddAsync(registro);
            return true;
        }

        public void Editar(TEntidade registro)
        {
            registros.Update(registro);
        }

        public void Excluir(TEntidade registro)
        {
            registros.Remove(registro);
        }

        public async Task<TEntidade> SelecionarPorIdAsync(Guid id)
        {
            return await registros.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<TEntidade>> SelecionarTodosAsync()
        {
            return await registros.ToListAsync();
        }

    }
}
