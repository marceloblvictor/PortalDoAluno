using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PortalDoAluno.Data;
using PortalDoAluno.Facade;
using PortalDoAluno.Repository;

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
            services.AddControllersWithViews();
            
            services.AddScoped<ICoursesRepository, CoursesRepository>();
            
            services.AddScoped<ICoursesFacade, CoursesFacade>();
            
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
                // Same as:
                //endpoints.MapControllerRoute(
                //name: "default",
                //pattern: "{controller=Home}/{action=Index}/{id?}");
                //});
                endpoints.MapDefaultControllerRoute();

            });    
        }
    }   
}
