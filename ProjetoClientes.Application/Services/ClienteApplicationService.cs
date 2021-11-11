using ProjetoClientes.Application.Interfaces;
using ProjetoClientes.Application.Models;
using ProjetoClientes.Domain.Entities;
using ProjetoClientes.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoClientes.Application.Services
{
    /// <summary>
    /// Classe de serviços de aplicação para cliente
    /// </summary>
    public class ClienteApplicationService : IClienteApplicationService
    {
        //atributo
        private readonly IClienteDomainService _clientedomainservice;

        //construtor para inicialização do atributo (injeção de dependência)
        public ClienteApplicationService(IClienteDomainService clientedomainservice)
        {
            _clientedomainservice = clientedomainservice;
        }

        public void Create(ClienteCadastroModel model)
        {
            var cliente = new Cliente();

            cliente.Nome = model.Nome;
            cliente.Email = model.Email;
            cliente.Cpf = model.Cpf;
            cliente.Telefone = model.Telefone;

            _clientedomainservice.Create(cliente);
        }

        public void Update(ClienteEdicaoModel model)
        {
            var cliente = _clientedomainservice.GetById(model.IdCliente);

            cliente.Nome = model.Nome;
            cliente.Email = model.Email;
            cliente.Cpf = model.Cpf;
            cliente.Telefone = model.Telefone;

            _clientedomainservice.Update(cliente);
        }

        public void Delete(Guid idCliente)
        {
            var cliente = _clientedomainservice.GetById(idCliente);
            _clientedomainservice.Delete(cliente);
        }

        public List<ClienteConsultaModel> GetAll()
        {
            var clientes = new List<ClienteConsultaModel>();

            foreach (var item in _clientedomainservice.GetAll())
            {
                var model = new ClienteConsultaModel();

                model.IdCliente = item.IdCliente;
                model.Nome = item.Nome;
                model.Email = item.Email;
                model.Cpf = item.Cpf;
                model.Telefone = item.Telefone;
                model.DataCadastro = item.DataCadastro;

                clientes.Add(model);
            }

            return clientes;
        }

        public List<ClienteConsultaModel> GetByDataCadastro(DateTime dataMin, DateTime dataMax)
        {
            var clientes = new List<ClienteConsultaModel>();

            foreach (var item in _clientedomainservice.GetByDataCadastro(dataMin, dataMax))
            {
                var model = new ClienteConsultaModel();

                model.IdCliente = item.IdCliente;
                model.Nome = item.Nome;
                model.Email = item.Email;
                model.Cpf = item.Cpf;
                model.Telefone = item.Telefone;
                model.DataCadastro = item.DataCadastro;

                clientes.Add(model);
            }

            return clientes;
        }

        public ClienteConsultaModel GetById(Guid idCliente)
        {
            var cliente = _clientedomainservice.GetById(idCliente);

            var model = new ClienteConsultaModel();

            model.IdCliente = cliente.IdCliente;
            model.Nome = cliente.Nome;
            model.Email = cliente.Email;
            model.Cpf = cliente.Cpf;
            model.Telefone = cliente.Telefone;
            model.DataCadastro = cliente.DataCadastro;

            return model;
        }
    }
}
