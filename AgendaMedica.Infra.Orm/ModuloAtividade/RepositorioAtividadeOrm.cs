using AgendaMedica.Dominio.Compartilhado;
using AgendaMedica.Dominio.ModuloAtividade;
using AgendaMedica.Infra.Orm.Compartilhado;
using EAgendaMedica.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaMedica.Infra.Orm.ModuloAtividade
{
    public class RepositorioAtividadeOrm : RepositorioBase<Atividade>, IRepositorioAtividade
    {
        public RepositorioAtividadeOrm(IContextoPersistencia dbContext) : base(dbContext)
        {
        }

        public override Atividade SelecionarPorId(Guid id) => registros.SingleOrDefault(x => x.Id == id);

        public override async Task<Atividade> SelecionarPorIdAsync(Guid id) => await registros
            .Include(a => a.Medicos)
            .ThenInclude(m => m.Atividades)
            .SingleOrDefaultAsync(a => a.Id == id);
    }
}