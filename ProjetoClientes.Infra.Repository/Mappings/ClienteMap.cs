using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoClientes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoClientes.Infra.Repository.Mappings
{
    /// <summary>
    /// Classe de mapeamento ORM para a entidade Cliente
    /// </summary>
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            //nome da tabela
            builder.ToTable("CLIENTE");

            //chave primária
            builder.HasKey(c => c.IdCliente);

            //mapeamento dos campos da tabela
            builder.Property(c => c.IdCliente)
                .HasColumnName("IDCLIENTE");

            builder.Property(c => c.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(c => c.Email)
                .HasColumnName("EMAIL")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Cpf)
                .HasColumnName("CPF")
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(c => c.Telefone)
                .HasColumnName("TELEFONE")
                .HasMaxLength(25)
                .IsRequired();

            builder.Property(c => c.DataCadastro)
                .HasColumnName("DATACADASTRO")
                .IsRequired();

            #region Mapeamento dos campos unicos (UNIQUE)

            builder.HasIndex(c => c.Email)
                .IsUnique();

            builder.HasIndex(c => c.Cpf)
                .IsUnique();

            builder.HasIndex(c => c.Telefone)
                .IsUnique();

            #endregion
        }
    }
}
