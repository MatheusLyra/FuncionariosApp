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
    public class FuncionarioMap : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.HasKey(f => f.Id);
            builder.Property(f => f.Id)
                .HasColumnName("ID");

            builder.Property(f => f.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(f => f.Matricula)
                .HasColumnName("MATRICULA")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(f => f.Cpf)
                .HasColumnName("CPF")
                .HasMaxLength(14)
                .IsRequired();

            builder.Property(f => f.DataAdmissao)
                .HasColumnName("DATAADMISSAO")
                .IsRequired();

            builder.Property(f => f.DataHoraCadastro)
                .HasColumnName("DATAHORACADASTRO")
                .IsRequired();

            builder.Property(f => f.EmpresaId)
                .HasColumnName("EMPRESAID")
                .IsRequired();

            builder.HasOne(e => e.Empresa)
                .WithMany(f => f.Funcionarios)
                .HasForeignKey(e => e.EmpresaId); 

        }
    }
}
