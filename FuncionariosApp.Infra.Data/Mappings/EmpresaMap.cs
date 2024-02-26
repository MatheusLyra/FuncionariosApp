using FuncionariosApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncionariosApp.Infra.Data.Mappings
{
    public class EmpresaMap : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("EMPRESA");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .HasColumnName("ID");

            builder.Property(e => e.NomeFantasia)
                .HasColumnName("NOMEFANTASIA")
                .HasMaxLength(80)
                .IsRequired();

            builder.Property(e => e.RazaoSocial)
                .HasColumnName("RAZAOSOCIAL")
                .HasMaxLength(160)
                .IsRequired();
            builder.HasIndex(e => e.RazaoSocial)
                .IsUnique();

            builder.Property(e => e.Cnpj)
                .HasColumnName("CNPJ")
                .HasMaxLength(18)
                .IsRequired();
            builder.HasIndex(e => e.Cnpj)
                .IsUnique();

            builder.Property(e => e.DataHoraCadastro)
                .HasColumnName("DATAHORACADASTRO")
                .IsRequired();

        }
    }
}
