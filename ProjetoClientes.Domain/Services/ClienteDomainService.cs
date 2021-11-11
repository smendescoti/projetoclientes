using ProjetoClientes.Domain.Entities;
using ProjetoClientes.Domain.Interfaces.Repositories;
using ProjetoClientes.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoClientes.Domain.Services
{
    /// <summary>
    /// Classe de regras de negócio para cliente
    /// </summary>
    public class ClienteDomainService : BaseDomainService<Cliente>, IClienteDomainService
    {
        //atributo
        private readonly IClienteRepository _clienterepository;

        //construtor para inicializar o atributo (injeção de dependência)
        public ClienteDomainService(IClienteRepository clienterepository) : base(clienterepository)
        {
            _clienterepository = clienterepository;
        }

        //Sobrescrever o método Create
        public override void Create(Cliente obj)
        {
            #region Não é permitido gravar clientes com o mesmo Email

            if (_clienterepository.GetByEmail(obj.Email) != null)
                throw new ArgumentException("O email informado já está cadastrado, tente outro.");

            #endregion

            #region Não é permitido gravar clientes com o mesmo Cpf

            if (_clienterepository.GetByCpf(obj.Cpf) != null)
                throw new ArgumentException("O cpf informado já está cadastrado, tente outro.");

            #endregion

            #region Não é permitido gravar clientes com o mesmo Telefone

            if(_clienterepository.GetByTelefone(obj.Telefone) != null)
                throw new ArgumentException("O telefone informado já está cadastrado, tente outro.");

            #endregion

            #region Cadastrar o Cliente

            obj.IdCliente = Guid.NewGuid();
            obj.DataCadastro = DateTime.Now;

            _clienterepository.Create(obj);

            #endregion
        }

        //Sobrescrita do método Update
        public override void Update(Cliente obj)
        {
            Cliente cliente;

            #region Não é permitido alterar o email do cliente utilizando um email já cadastrado para outro cliente

            cliente = _clienterepository.GetByEmail(obj.Email);

            if(cliente != null && cliente.IdCliente != obj.IdCliente)
                throw new ArgumentException("O email informado já está cadastrado para outro cliente.");

            #endregion

            #region Não é permitido alterar o cpf do cliente utilizando um cpf já cadastrado para outro cliente

            cliente = _clienterepository.GetByCpf(obj.Cpf);

            if (cliente != null && cliente.IdCliente != obj.IdCliente)
                throw new ArgumentException("O cpf informado já está cadastrado para outro cliente.");

            #endregion

            #region Não é permitido alterar o telefone do cliente utilizando telefone cpf já cadastrado para outro cliente

            cliente = _clienterepository.GetByTelefone(obj.Telefone);

            if (cliente != null && cliente.IdCliente != obj.IdCliente)
                throw new ArgumentException("O telefone informado já está cadastrado para outro cliente.");

            #endregion

            #region Atualizar o cliente

            _clienterepository.Update(obj);

            #endregion
        }

        //Consultar os clientes cadastrados dentro do periodo de datas
        public List<Cliente> GetByDataCadastro(DateTime dataMin, DateTime dataMax)
        {
            #region A data inicial deve ser menor ou igual a data final

            if (dataMin > dataMax)
                throw new ArgumentException("A data de início deve ser menor ou igual a data de término.");

            #endregion

            #region Executar a consulta e retornar os dados

            return _clienterepository.GetByDataCadastro(dataMin, dataMax);

            #endregion
        }
    }
}
