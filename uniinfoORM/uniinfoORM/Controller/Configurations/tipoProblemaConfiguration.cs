using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using uniinfoORM.Model;

namespace uniinfoORM.Controller.Configurations
{
    public class tipoProblemaConfiguration : IEntityTypeConfiguration<tipoProblema>
    {
        public void Configure(EntityTypeBuilder<tipoProblema> builder)
        {
            builder
                .ToTable("tipoProblema");

            builder
                .Property(tp => tp.Id)
                .HasColumnName("idProblema");

            builder
                .Property(tp => tp.tipoDoProblema)
                .HasColumnName("tipoProblema")
                .HasColumnType("nvarchar(20)")
                .IsRequired();
        }
    }
}
