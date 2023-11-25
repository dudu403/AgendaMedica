using AgendaMedica.Dominio.Compartilhado;
using AgendaMedica.Dominio.ModuloAtividade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaMedica.Dominio.ModuloMedico
{
    public class Medico : Entidade
    {
        public string Nome { get; set; }
        public string CRM { get; set; }
        public string telefone { get; set; }
        public string endereco { get; set; }
        public string email { get; set; }
    }
}
