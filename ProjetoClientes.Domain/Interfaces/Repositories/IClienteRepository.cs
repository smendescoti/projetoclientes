using ProjetoClientes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoClientes.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interface especifica para operações de repositorio voltadas para Cliente
    /// </summary>
    public interface IClienteRepository : IBaseRepository<Cliente>
    {

    }
}
