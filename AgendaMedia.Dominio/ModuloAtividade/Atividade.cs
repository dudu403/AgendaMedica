using AgendaMedica.Dominio.Compartilhado;
using AgendaMedica.Dominio.ModuloMedico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaMedica.Dominio.ModuloAtividade
{
    public class Atividade : Entidade
    {
        public Medico Medico { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan HorarioInicio { get; set; }
        public TimeSpan HorarioTernino { get; set; }
        public CategoriaEnum Categoria { get; set; }
        public Guid MedicoID { get; set; }
    }
}
