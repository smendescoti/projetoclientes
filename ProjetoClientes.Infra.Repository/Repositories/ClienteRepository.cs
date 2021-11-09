using ProjetoClientes.Domain.Entities;
using ProjetoClientes.Domain.Interfaces.Repositories;
using ProjetoClientes.Infra.Repository.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoClientes.Infra.Repository.Repositories
{
    /// <summary>
    /// Classe que implementa o repositorio de dados para Cliente
    /// </summary>
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        //atributo
        private readonly SqlServerContext _context;

        //construtor para inicializar o atributo por meio de injeção de dependência
        public ClienteRepository(SqlServerContext context) : base(context)
        {
            _context = context;
        }
    }
}
