using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoClientes.Services.Configurations
{
    /// <summary>
    /// Classe para configuração de CORS (permissão para outros servidores acessem a API)
    /// </summary>
    public class CorsConfiguration
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(
                   s => s.AddPolicy("DefaultPolicy", builder =>
                   {
                       builder.AllowAnyOrigin() //qualquer origem pode acessar a API
                              .AllowAnyMethod() //qualquer método (POST, PUT, DELETE, GET)
                              .AllowAnyHeader(); //qualquer informação de cabeçalho
                    })
               );
        }

        public static void Configure(IApplicationBuilder app)
        {
            app.UseCors("DefaultPolicy");
        }
    }
}
