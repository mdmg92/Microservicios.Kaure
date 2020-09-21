using MediatR;
using Microservicios.Kaure.Cross.RabbitMQ.Bus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Microservicios.Kaure.Cross.RabbitMQ
{
    public static class Extensions
    {
        public static TModel GetOptions<TModel>(this IConfiguration configuration, string section) where TModel : new()
        {
            var model = new TModel();
            configuration.GetSection(section).Bind(model);

            return model;
        }
        
        private static readonly string RabbitMQSectionName = "rabbitmq";

        public static IServiceCollection AddRabbitMQ(this IServiceCollection services)
        {
            IConfiguration configuration;
            using (var serviceProvider = services.BuildServiceProvider())
            {
                configuration = serviceProvider.GetService<IConfiguration>();
            }

            //var options = configuration.GetOptions<RabbitMqOptions>(RabbitMQSectionName);
            services.Configure<RabbitMqOptions>(configuration.GetSection(RabbitMQSectionName));

            services.AddSingleton<IEventBus, RabbitMQBus>(sp =>
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new RabbitMQBus(sp.GetService<IMediator>(), scopeFactory, configuration);
            });

            return services;
        }
    }
}
