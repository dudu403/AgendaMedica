﻿using AgendaMedica.Dominio.ModuloAtividade;
using AgendaMedica.Dominio.ModuloMedico;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace AgendaMedica.Infra.Orm.ModuloAtividade
{
    public class MapeadorAtividadeOrm : IEntityTypeConfiguration<Atividade>
    {
        public void Configure(EntityTypeBuilder<Atividade> builder)
        {
            builder.ToTable("TBAtividade");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Data).IsRequired();
            builder.Property(x => x.HorarioInicio).IsRequired();
            builder.Property(x => x.HorarioTernino).IsRequired();
            builder.Property(x => x.Categoria).HasConversion<int>();
            builder.HasOne(x => x.Medico).WithMany().HasForeignKey(x => x.MedicoID)
            .HasConstraintName("FK_TBMedico_TBAtividade").OnDelete(DeleteBehavior.NoAction);
        }
    }
}
