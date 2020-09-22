using MediatR;
using Microservicios.Kaure.Cross.Proxy;
using Microservicios.Kaure.Cross.RabbitMQ;
using Microservicios.Kaure.Withdrawal.RabbitMQ.Commands;
using Microservicios.Kaure.Withdrawal.RabbitMQ.Handlers;
using Microservicios.Kaure.Withdrawal.Repositories;
using Microservicios.Kaure.Withdrawal.Repositories.Data;
using Microservicios.Kaure.Withdrawal.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Microservicios.Kaure.Withdrawal
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

            services.AddDbContext<WithdrawalContext>(
              options =>
              {
                  options.UseNpgsql(Configuration.GetConnectionString("Postgres"));
              });

            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<IWithdrawalContext, WithdrawalContext>();
            
            services.AddMediatR(typeof(Startup));
            services.AddRabbitMQ();
            services.AddTransient<IRequestHandler<WithdrawalCreateCommand, bool>, WithdrawalCommandHandler>();
            services.AddTransient<IRequestHandler<NotificateTransactionCommand, bool>, NotificationCommandHandler>();

            services.AddProxyHttp();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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
        }
    }
}
