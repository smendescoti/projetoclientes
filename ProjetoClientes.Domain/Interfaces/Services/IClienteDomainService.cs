using ProjetoClientes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoClientes.Domain.Interfaces.Services
{
    /// <summary>
    /// Interface para definir métodos de serviço de dominio para cliente
    /// </summary>
    public interface IClienteDomainService : IBaseDomainService<Cliente>
    {
        List<Cliente> GetByDataCadastro(DateTime dataMin, DateTime dataMax);
    }
}
