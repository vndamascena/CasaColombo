﻿using Microsoft.OpenApi.Models;
using System.Reflection;

namespace CasaColombo.Services.Extensions
{
    public class SwaggerExtension
    {
        //método para implementar a configuração do swagger
        public static void AddSwaggerConfig(IServiceCollection services)
        {
            //habilitar o swagger no projeto
            services.AddEndpointsApiExplorer();

            //customizando a documentação gerada pelo swagger
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "CasaColombo - API ",
                    Description = "API desenvolvida em .NET 9 com EntityFramework",
                    Version = "2.0",
                    Contact = new OpenApiContact
                    {
                        Name = "Casa Colombo",
                        Email = "Adm@casacolombo.net.br",

                    }
                });

                //adicionar os comentários XML do código na página do swagger
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

            });
        }

        //método para gerar um link para criarmos projetos de testes
        //para esta API usando POSTMAN, INSOMNIA etc.
        public static void UseSwaggerConfig(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "CasaColombo");
            });
        }
    }
}
