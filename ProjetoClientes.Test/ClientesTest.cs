using Bogus;
using Bogus.Extensions.Brazil;
using FluentAssertions;
using Newtonsoft.Json;
using ProjetoClientes.Application.Models;
using ProjetoClientes.Test.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProjetoClientes.Test
{
    public class ClientesTest
    {
        [Fact]
        public async Task Test_CadastrarCliente()
        {
            //criando objeto para preenchimento dos dados
            var faker = new Faker("pt_BR");

            //dados que serão enviados para o teste
            var model = new ClienteCadastroModel
            {
                Nome = faker.Person.FullName,
                Email = faker.Person.Email.ToLower(),
                Cpf = faker.Person.Cpf(false),
                Telefone = faker.Person.Phone
            };

            //conectar na API
            var client = HttpClientHelper.Create();

            //criando a requisição e executar o cadastro
            var content = new StringContent(JsonConvert.SerializeObject(model),
                Encoding.UTF8, "application/json");

            //enviando a requisição de cadastro para a API..
            var response = await client.PostAsync("api/clientes", content);

            //verificando o retorno obtido..
            response.StatusCode
                .Should()
                .Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Test_AtualizarCliente()
        {
            //consultar todos os clientes
            var clientes = await Test_ConsultarClientes();

            //capturar o primeiro cliente obtido na consulta
            var cliente = clientes.FirstOrDefault();

            //criando objeto para preenchimento dos dados
            var faker = new Faker("pt_BR");

            //alterando os dados do cliente
            var model = new ClienteEdicaoModel
            {
                IdCliente = cliente.IdCliente,
                Nome = faker.Person.FullName,
                Email = faker.Person.Email.ToLower(),
                Cpf = faker.Person.Cpf(false),
                Telefone = faker.Person.Phone
            };

            //conectar na API
            var client = HttpClientHelper.Create();

            //criando a requisição e executar o cadastro
            var content = new StringContent(JsonConvert.SerializeObject(model),
                Encoding.UTF8, "application/json");

            //enviando a requisição de edição para a API..
            var response = await client.PutAsync("api/clientes", content);

            //verificando o retorno obtido..
            response.StatusCode
                .Should()
                .Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Test_ExcluirCliente()
        {
            //consultar todos os clientes
            var clientes = await Test_ConsultarClientes();

            //capturar o ultimo cliente obtido na consulta
            var cliente = clientes.LastOrDefault();

            //conectar na API
            var client = HttpClientHelper.Create();

            //excluindo o cliente
            var response = await client.DeleteAsync($"api/clientes/{cliente.IdCliente}");

            //verificando o retorno obtido..
            response.StatusCode
                .Should()
                .Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task<List<ClienteConsultaModel>> Test_ConsultarClientes()
        {
            //conectar na API
            var client = HttpClientHelper.Create();

            //enviando a requisição de consulta para a API..
            var response = await client.GetAsync("api/clientes");

            //capturando o retorno da consulta
            var result = JsonConvert.DeserializeObject<List<ClienteConsultaModel>>
                (response.Content.ReadAsStringAsync().Result);

            //verificando se a consulta foi feita com sucesso
            response.StatusCode
                .Should()
                .Be(HttpStatusCode.OK);

            //verificando se pelos 1 registro foi obtido
            result.Should().NotBeEmpty();

            //retornar os dados da consulta
            return result;
        }

        [Fact]
        public async Task Test_ConsultarClientesPorDataDeCadastro()
        {
            var dataMin = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
            var dataMax = DateTime.Now.AddDays(+1).ToString("yyyy-MM-dd");

            //conectar na API
            var client = HttpClientHelper.Create();

            //enviando a requisição de consulta para a API..
            var response = await client.GetAsync($"api/clientes/{dataMin}/{dataMax}");

            //capturando o retorno da consulta
            var result = JsonConvert.DeserializeObject<List<ClienteConsultaModel>>
                (response.Content.ReadAsStringAsync().Result);

            //verificando o resultado
            response.StatusCode
                .Should()
                .Be(HttpStatusCode.OK);

            //verificando se pelos 1 registro foi obtido
            result.Should().NotBeEmpty();
        }

        [Fact]
        public async Task Test_ObterClientePorId()
        {
            //consultar todos os clientes
            var clientes = await Test_ConsultarClientes();

            //capturar o id de 1 cliente
            var idCliente = clientes.FirstOrDefault().IdCliente;

            //conectar na API
            var client = HttpClientHelper.Create();

            //enviando a requisição de consulta para a API..
            var response = await client.GetAsync($"api/clientes/{idCliente}");

            //capturando o retorno da consulta
            var result = JsonConvert.DeserializeObject<ClienteConsultaModel>
                (response.Content.ReadAsStringAsync().Result);

            //verificando o resultado
            response.StatusCode
                .Should()
                .Be(HttpStatusCode.OK);

            //verificando se o registro foi obtido
            result.Should().NotBeNull();
        }
    }
}
