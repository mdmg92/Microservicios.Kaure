using Consul;
using Microservicios.Kaure.Cross.Consul.Consul;
using Microservicios.Kaure.Cross.Consul.Mvc;
using Microservicios.Kaure.Cross.Jwt;
using Microservicios.Kaure.Security.Repositories;
using Microservicios.Kaure.Security.Repositories.Data;
using Microservicios.Kaure.Security.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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

            services.AddDbContext<SecurityContext>(o =>
            {
                o.UseMySQL(Configuration.GetConnectionString("MySQL"));
            });

            services.AddScoped<IAccessService, AccessService>();
            services.AddScoped<IAccessRepository, AccessRepository>();
            services.AddScoped<IContextDatabase, SecurityContext>();
            
            services.AddSingleton<IServiceId, ServiceId>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddConsul();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app, 
            IWebHostEnvironment env,
            IHostApplicationLifetime applicationLifetime,
            IConsulClient consulClient
        ) {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            
            var serviceId = app.UseConsul();
            applicationLifetime.ApplicationStopped.Register(() =>
            {
                consulClient.Agent.ServiceDeregister(serviceId);
            });
        }
    }
}
