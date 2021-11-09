using Microsoft.EntityFrameworkCore;
using ProjetoClientes.Domain.Entities;
using ProjetoClientes.Infra.Repository.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoClientes.Infra.Repository.Contexts
{
    /// <summary>
    /// Classe de conexão com o banco de dados atraves do EF
    /// </summary>
    public class SqlServerContext : DbContext
    {
        //construtor para inicializar a classe por meio de injeção de dependência
        public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options)
        {

        }

        //declarar uma propriedade DbSet para cada entidade
        public DbSet<Cliente> Cliente { get; set; }

        //adicionar cada classe de mapeamento feita no projeto
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteMap());
        }
    }
}
