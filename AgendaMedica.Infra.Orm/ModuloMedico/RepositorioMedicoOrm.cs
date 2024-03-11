using AgendaMedica.Dominio.Compartilhado;
using AgendaMedica.Dominio.ModuloMedico;
using AgendaMedica.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaMedica.Infra.Orm.ModuloMedico
{
    public class RepositorioMedicoOrm : RepositorioBase<Medico>, IRepositorioMedico
    {
        public RepositorioMedicoOrm(IContextoPersistencia dbContext) : base(dbContext)
        {

        }
        public override Medico SelecionarPorId(Guid id) => registros.SingleOrDefault(x => x.Id == id);

        public override async Task<Medico> SelecionarPorIdAsync(Guid id) => await registros.Include(x => x.Atividades).SingleOrDefaultAsync(x => x.Id == id);
    }
}
