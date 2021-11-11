using ProjetoClientes.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoClientes.Application.Interfaces
{
    /// <summary>
    /// Interface para definir os métodos da camada de serviços de aplicação
    /// </summary>
    public interface IClienteApplicationService
    {
        void Create(ClienteCadastroModel model);
        void Update(ClienteEdicaoModel model);
        void Delete(Guid idCliente);

        List<ClienteConsultaModel> GetAll();
        List<ClienteConsultaModel> GetByDataCadastro(DateTime dataMin, DateTime dataMax);
        ClienteConsultaModel GetById(Guid idCliente);
    }
}
