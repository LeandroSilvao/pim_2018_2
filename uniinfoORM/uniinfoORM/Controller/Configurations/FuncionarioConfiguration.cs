using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using uniinfoORM.Model;

namespace uniinfoORM.Controller.Configurations
{
    public class FuncionarioConfiguration : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder
                .ToTable("Funcionario");

            builder
                .Property(f => f.Id)
                .HasColumnName("idFuncionario");

            builder
                .Property(f => f.nome)
                .HasColumnName("nome")
                .HasColumnType("varchar(30)");

            builder
                .Property(f => f.ramal)
                .HasColumnName("ramal")
                .HasColumnType("int");

            builder
                .Property(f => f.nComputador)
                .HasColumnName("nComputador")
                .HasColumnType("int");

            builder
                .Property(f => f.email)
                .HasColumnName("email")
                .HasColumnType("nvarchar(30)")
                .IsRequired();

            builder
                .Property(f => f.setor)
                .HasColumnName("setor")
                .HasColumnType("nvarchar(30)")
                .IsRequired();

            builder
                .Property(f => f.nivelAcesso)
                .HasColumnName("nivelAcesso")
                .HasColumnType("nivelAcesso(30)")
                .IsRequired();

            builder
                .Property<int>("idLogin");

            builder
                .HasOne(f => f.loginId)
                .WithMany(l => l.Funcionarios)
                .HasForeignKey("idLogin");

        }
    }
}
