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

        public Cliente GetByEmail(string email)
        {
            return _context.Cliente
                .FirstOrDefault(c => c.Email.Equals(email));
        }

        public Cliente GetByCpf(string cpf)
        {
            return _context.Cliente
                .FirstOrDefault(c => c.Cpf.Equals(cpf));
        }

        public Cliente GetByTelefone(string telefone)
        {
            return _context.Cliente
                .FirstOrDefault(c => c.Telefone.Equals(telefone));
        }

        public List<Cliente> GetByDataCadastro(DateTime dataMin, DateTime dataMax)
        {
            return _context.Cliente
                .Where(c => c.DataCadastro >= dataMin && c.DataCadastro <= dataMax)
                .OrderBy(c => c.DataCadastro)
                .ToList();
        }
    }
}
