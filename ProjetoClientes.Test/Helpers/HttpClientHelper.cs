using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using ProjetoClientes.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoClientes.Test.Helpers
{
    /// <summary>
    /// Classe para fazer a execução da API para os testes
    /// </summary>
    public class HttpClientHelper
    {
        public static HttpClient Create()
        {
            //lendo o arquivo 'appsettings.json' do projeto API
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            //gerar uma conexão com a API
            var server = new TestServer(new WebHostBuilder()
                .UseConfiguration(configuration)
                .UseStartup<Startup>());

            return server.CreateClient();
        }
    }
}
