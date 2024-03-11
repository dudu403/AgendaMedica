using AgendaMedica.Dominio.ModuloAtividade;
using AgendaMedica.Dominio.ModuloMedico;
using FluentValidation;

namespace EAgendaMedica.Dominio.ModuloAtividade
{
    public class ValidadorAtividade : AbstractValidator<Atividade>
    {
        public ValidadorAtividade()
        {

            RuleFor(x => x.Data).NotNull().NotEmpty();
            RuleFor(x => x.HorarioInicio).NotNull();
            RuleFor(x => x.HorarioTernino).NotNull();
            RuleFor(x => x.Categoria).IsInEnum().Must(tipo => tipo == CategoriaEnum.Cirurgia || tipo == CategoriaEnum.Consulta);
            RuleFor(a => a.Medicos.Count).Equal(1).When(a => a.Categoria == CategoriaEnum.Consulta).WithMessage("A consulta só deve ter um médico selecionado.");
            RuleFor(a => a.Medicos).NotEmpty().WithMessage("Pelo Menos um médico deve ser selecionado.");

        }

        public bool ConfirmarSeAtividadeTemConflitoDeHorario(Atividade atividade)
        {

            foreach (Medico medico in atividade.Medicos ?? Enumerable.Empty<Medico>())
            {
                foreach (Atividade atividadeDoMedico in medico.Atividades ?? Enumerable.Empty<Atividade>())
                {

                    if (atividade.Id != atividadeDoMedico.Id)
                    {
                        // Verifica se os médicos da atividade possuem outra atividade no mesmo dia ou no dia anterior
                        if ((atividade.Data == atividadeDoMedico.Data) ||
                            (atividadeDoMedico.HorarioInicio >= atividadeDoMedico.HorarioTernino && atividadeDoMedico.Data.AddDays(1) == atividade.Data))
                        {

                            if (atividade.HorarioInicio >= atividadeDoMedico.HorarioInicio && atividade.HorarioInicio <= atividadeDoMedico.HorarioTernino ||
                                atividade.HorarioTernino >= atividadeDoMedico.HorarioTernino && atividade.HorarioTernino <= atividadeDoMedico.HorarioTernino)
                            {
                                return true;
                            }

                            TimeSpan diferenca = atividadeDoMedico.HorarioTernino - atividade.HorarioInicio;

                            // Restante da lógica de verificação de conflito
                            if ((atividade.Categoria == CategoriaEnum.Consulta && diferenca.TotalMinutes < 20) ||
                                (atividade.Categoria == CategoriaEnum.Cirurgia && diferenca.TotalMinutes < 240))
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

    }
}