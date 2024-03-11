using FluentValidation;

namespace AgendaMedica.Dominio.ModuloMedico
{
    public class ValidadorMedico : AbstractValidator<Medico>
    {
        public ValidadorMedico()
        {
            RuleFor(x => x.Nome).NotNull().NotEmpty();
            RuleFor(x => x.CRM).NotNull().NotEmpty().WithMessage("O CRM deve estar no seguinte formato '00000-AA'");
            RuleFor(x => x.Endereco).NotNull().NotEmpty(); // Corrigido para Endereco
            RuleFor(x => x.Telefone).NotNull().NotEmpty();
            RuleFor(x => x.Email).NotNull().NotEmpty(); // Corrigido para Email
        }
    }
}
