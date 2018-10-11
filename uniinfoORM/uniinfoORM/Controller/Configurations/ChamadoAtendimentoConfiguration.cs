using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using uniinfoORM.Model;

namespace uniinfoORM.Controller.Configurations
{
    public class ChamadoAtendimentoConfiguration : IEntityTypeConfiguration<ChamadoAtendimento>
    {
        public void Configure(EntityTypeBuilder<ChamadoAtendimento> builder)
        {
            builder
                .ToTable("ChamadoAtendimento");

            builder
                .Property(ca => ca.id)
                .HasColumnName("idAtendimento");

            builder
                .Property<int>("idFuncionario");
            builder
                .Property<int>("idChamado");

            builder
                .Property<DateTime?>("dataAtendimento");

            builder
                .HasOne(ca => ca.IdFuncionario)
                .WithMany(f => f.ChamadosPorFuncionario)
                .HasForeignKey("idFuncionario");

            builder
                .HasOne(ca => ca.IdChamado)
                .WithMany(c => c.chamados)
                .HasForeignKey("idChamado");
        }
    }
}
