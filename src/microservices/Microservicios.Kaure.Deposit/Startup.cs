using Consul;
using MediatR;
using Microservicios.Kaure.Cross.Consul.Consul;
using Microservicios.Kaure.Cross.Consul.Mvc;
using Microservicios.Kaure.Cross.Proxy;
using Microservicios.Kaure.Cross.RabbitMQ;
using Microservicios.Kaure.Deposit.RabbitMQ.Commands;
using Microservicios.Kaure.Deposit.RabbitMQ.Handlers;
using Microservicios.Kaure.Deposit.Repositories;
using Microservicios.Kaure.Deposit.Repositories.Data;
using Microservicios.Kaure.Deposit.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Microservicios.Kaure.Deposit
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
            services.AddControllers();

            services.AddDbContext<DepositContext>(
              options =>
              {
                  options.UseNpgsql(Configuration.GetConnectionString("Postgres"));
              });

            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<IDepositContext, DepositContext>();
            
            services.AddMediatR(typeof(Startup));
            services.AddRabbitMQ();
            services.AddTransient<IRequestHandler<DepositCreateCommand, bool>, DepositCommandHandler>();
            services.AddTransient<IRequestHandler<NotificateTransactionCommand, bool>, NotificationCommandHandler>();
            
            services.AddProxyHttp();
            
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

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
            var serviceId = app.UseConsul();
            applicationLifetime.ApplicationStopped.Register(() =>
            {
                consulClient.Agent.ServiceDeregister(serviceId);
            });
        }
    }
}
