using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaMedica.Dominio.ModuloMedico
{
    public class ValidadorMedico : AbstractValidator<Medico>
    {
        public ValidadorMedico() 
        {
            RuleFor(x => x.Nome).NotNull().NotEmpty();
            RuleFor(x => x.CRM).NotNull().NotEmpty().WithMessage("O CRM deve estar no seguinte formato '00000-AA'");
            RuleFor(x => x.endereco).NotNull().NotEmpty();
            RuleFor(x => x.telefone).NotNull().NotEmpty();
            RuleFor(x => x.email).NotNull().NotEmpty();
        }
    }
}
