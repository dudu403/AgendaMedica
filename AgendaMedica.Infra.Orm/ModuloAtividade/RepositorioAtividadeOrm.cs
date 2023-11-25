using AgendaMedica.Dominio.Compartilhado;
using AgendaMedica.Dominio.ModuloAtividade;
using AgendaMedica.Infra.Orm.Compartilhado;
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
    }
}
