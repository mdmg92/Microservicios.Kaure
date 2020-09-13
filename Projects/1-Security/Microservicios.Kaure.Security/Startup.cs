using Microservicios.Kaure.Cross.Jwt;
using Microservicios.Kaure.Security.Repositories;
using Microservicios.Kaure.Security.Repositories.Data;
using Microservicios.Kaure.Security.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Microservicios.Kaure.Security
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<JwtOptions>(Configuration.GetSection("jwt"));

            services.AddControllers();

            services.AddDbContext<ContextDatabase>(o =>
            {
                o.UseMySQL(Configuration["mysql:cn"]);
            });

            services.AddScoped<IAccessService, AccessService>();
            services.AddScoped<IAccessRepository, AccessRepository>();
            services.AddScoped<IContextDatabase, ContextDatabase>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
