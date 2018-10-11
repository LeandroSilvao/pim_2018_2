using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using uniinfoORM.Model;

namespace uniinfoORM.Controller.Configurations
{
    public class ChamadoConfiguration : IEntityTypeConfiguration<Chamado>
    {
        public void Configure(EntityTypeBuilder<Chamado> builder)
        {
            builder
                .ToTable("Chamado");

            builder
                .Property(c => c.Id)
                .HasColumnName("idChamado")
                .HasColumnType("int");

            builder
                .Property(c => c.descricao)
                .HasColumnName("descricao")
                .HasColumnType("nvarchar(300)")
                .IsRequired();

            builder
                .Property<DateTime>("dataChamado");

            builder
                .Property(c => c.statusAtendimento)
                .HasColumnName("statusAtendimento")
                .HasColumnType("nvarchar(20)")
                .IsRequired();



            builder
                .Property<int>("idProblema");

            builder
                .HasOne(c => c.IdProblema)
                .WithMany(tp => tp.problemaId)
                .HasForeignKey("idProblema");

            builder
                .Property<int>("idFuncionario");

            builder
                .HasOne(c => c.IdFuncionario)
                .WithMany(f => f.FuncionarioId)
                .HasForeignKey("idFuncionario");
        }
    }
}
