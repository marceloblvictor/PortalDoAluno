using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PortalDoAluno.Data;

namespace PortalDoAluno
{
    public class Startup
    {

        // Container de injeção de dependências
        public void ConfigureServices(IServiceCollection services)
        {
            // Adiciona os controllers do MVC como uma dependência da aplicação
            services.AddControllers();

            // Adiciona o Context do Entity Framework como uma dependência da aplicação
            // Obtém a connection string de appsettings.json
            services.AddDbContext<PortalDoAlunoDbContext>(
                    options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection:PortalDoAlunoDb")
                );
        }

        // Pipeline dos requests HTTP.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
