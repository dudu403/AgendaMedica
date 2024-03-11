using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaMedica.Dominio.ModuloAtividade
{
    public class ValidadorAtividade : AbstractValidator<Atividade>
    {
        public ValidadorAtividade()
        {
            RuleFor(x => x.Data).NotNull().NotEmpty();
            RuleFor(x => x.HorarioInicio).NotNull().NotEmpty();
            RuleFor(x => x.HorarioTernino).NotNull().NotEmpty();
            RuleFor(x => x.Categoria).NotNull().NotEmpty();
        }
    }
}
