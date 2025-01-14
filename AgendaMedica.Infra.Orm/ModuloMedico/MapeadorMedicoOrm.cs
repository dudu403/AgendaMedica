﻿using AgendaMedica.Dominio.ModuloMedico;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendaMedica.Infra.Orm.ModuloAtividade
{
    public class MapeadorMedicoOrm : IEntityTypeConfiguration<Medico>
    {
        public void Configure(EntityTypeBuilder<Medico> builder)
        {
            builder.ToTable("TBMedico");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Nome).IsRequired();
            builder.Property(x => x.CRM).IsRequired();
            builder.Property(x => x.Telefone).IsRequired();
            builder.Property(x => x.Endereco).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.HasMany(x => x.Atividades).WithMany(x => x.Medicos).UsingEntity(x => x.ToTable("TBMedico_TBAtividade"));
        }
    }
}
