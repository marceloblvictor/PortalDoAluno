using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PortalDoAluno.Data;

namespace PortalDoAluno
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }

        public IConfiguration Configuration { get; }

        // Container de injeção de dependências
        public void ConfigureServices(IServiceCollection services)
        {
            // Adiciona os controllers (com views) do MVC como uma dependência da aplicação
            services.AddControllersWithViews();

            // Adiciona o Context do Entity Framework como uma dependência da aplicação
            // Obtém a connection string de appsettings.json
            services.AddDbContext<PortalDoAlunoDbContext>(
                    options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection")
                );
        }

        // Pipeline dos requests HTTP.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();

            });
        }
    }
}
