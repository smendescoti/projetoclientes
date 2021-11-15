using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjetoClientes.Application.Interfaces;
using ProjetoClientes.Application.Services;
using ProjetoClientes.Domain.Interfaces.Repositories;
using ProjetoClientes.Domain.Interfaces.Services;
using ProjetoClientes.Domain.Services;
using ProjetoClientes.Infra.Repository.Contexts;
using ProjetoClientes.Infra.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoClientes.Services.Configurations
{
    /// <summary>
    /// Classe para configuração da injeção de dependência do projeto.
    /// </summary>
    public class DependencyInjectionConfiguration
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            //capturar a connectionstring do banco de dados (appsettings.json)
            var connectionstring = configuration.GetConnectionString("Conexao");

            //mapear a injeção de dependência para a classe 'SqlServerContext' localizada
            //no projeto Repository (classe que irá fazer a conexão com o banco de dados)
            services.AddDbContext<SqlServerContext>(options => options.UseSqlServer(connectionstring));

            //mapear a injeção de dependencia das demais classes e interfaces do sistema
            services.AddTransient<IClienteApplicationService, ClienteApplicationService>();
            services.AddTransient<IClienteDomainService, ClienteDomainService>();
            services.AddTransient<IClienteRepository, ClienteRepository>();
        }
    }
}
