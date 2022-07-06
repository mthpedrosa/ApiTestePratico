using AR.Data;
using AR.Data.Imp;
using AR.Data.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace AR.Apresentacao
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API Teste Pratico", Version = "v1" , Description = "API para a manipulação de dados do Cliente. | Desenvolvida para o teste pratico da Ploomes"});

                var arquivoSwaggerXML = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var diretorioArquivoXML = Path.Combine(AppContext.BaseDirectory, arquivoSwaggerXML);
                c.IncludeXmlComments(diretorioArquivoXML);

            });


            

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddDbContext<ContextoPrincipal>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("ApiRest")));
        }

         public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Teste Pratico v1"));




            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = string.Empty;
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });
        }
    }
}
