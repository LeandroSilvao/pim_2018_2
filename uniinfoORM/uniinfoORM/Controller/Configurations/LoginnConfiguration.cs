using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using uniinfoORM.Model;

namespace uniinfoORM.Controller.Configurations
{
    public class LoginnConfiguration : IEntityTypeConfiguration<Loginn>
    {
        public void Configure(EntityTypeBuilder<Loginn> builder)
        {
            builder
                .ToTable("Loginn");

            builder
                .Property(l => l.Id)
                .HasColumnName("idLogin");

            builder
                .Property(l => l.loginn)
                .HasColumnName("loginn")
                .HasColumnType("varchar(30)");

            builder
                .Property(l => l.senha)
                .HasColumnName("senha")
                .HasColumnType("varchar(30)");
        }
    }
}
