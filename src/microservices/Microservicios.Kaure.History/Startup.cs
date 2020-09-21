using MediatR;
using Microservicios.Kaure.Cross.RabbitMQ;
using Microservicios.Kaure.Cross.RabbitMQ.Bus;
using Microservicios.Kaure.History.RabbitMQ.Events;
using Microservicios.Kaure.History.RabbitMQ.Handlers;
using Microservicios.Kaure.History.Repository;
using Microservicios.Kaure.History.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Microservicios.Kaure.History
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

            services.AddScoped<IHistoryService, HistoryService>();
            services.AddScoped<IRepositoryHistory, RepositoryHistory>();
            
            services.AddMediatR(typeof(Startup));
            services.AddRabbitMQ();
            services.AddTransient<DepositEventHandler>();
            services.AddTransient<IEventHandler<DepositCreatedEvent>, DepositEventHandler>();
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
            
            ConfigureEventBus(app);
        }
        
        private void ConfigureEventBus(IApplicationBuilder app)
        {
            var bus = app.ApplicationServices.GetRequiredService<IEventBus>();
            bus.Subscribe<DepositCreatedEvent, DepositEventHandler>();
        }
    }
}
