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
        public Medico medico { get; set; }
        public DateTime data { get; set; }
        public TimeSpan HorarioInicio { get; set; }
        public string TipoAtendimento { get; set; }
       
    }
}
