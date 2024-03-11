using AgendaMedica.Dominio.Compartilhado;
using AgendaMedica.Dominio.ModuloAtividade;
using System.Collections.Generic;

namespace AgendaMedica.Dominio.ModuloMedico
{
    public class Medico : Entidade
    {
        public string Nome { get; set; }
        public string CRM { get; set; }
        public string Telefone { get; set; } // Corrigido para string
        public string Endereco { get; set; } // Corrigido para string
        public string Email { get; set; } // Corrigido para string
        public List<Atividade> Atividades { get; set; }

        public Medico()
        {
            Atividades = new List<Atividade>();
        }
    }
}
