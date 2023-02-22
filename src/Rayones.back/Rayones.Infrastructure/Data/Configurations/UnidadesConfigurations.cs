using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rayones.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rayones.Infrastrucure.Data.Configurations
{
    class UnidadesConfigurations : IEntityTypeConfiguration<Unidades>
    {
        public void Configure(EntityTypeBuilder<Unidades> builder)
        {

            builder.HasKey(e => e.Id);
            builder.ToTable("Unidades");

            builder.Property(e => e.Id)
            .HasColumnName("Id");


            builder.Property(e => e.Descripcion)
                .IsRequired()
                .HasColumnName("Descripcion")
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}
