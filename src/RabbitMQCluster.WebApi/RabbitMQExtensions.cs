using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using System;

namespace RabbitMQCluster.WebApi
{
    static class RabbitMQExtensions
    {
        public static void AddRabbitMQ(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<RabbitMQConfig>(configuration.GetSection("RabbitMQ"));
            services.AddSingleton<IConnection>(CreateConnection);
            services.AddSingleton<IModel>(CreateChannel);
        }

        private static IConnection CreateConnection(IServiceProvider serviceProvider)
        {
            var rabbitMQConfig = serviceProvider.GetRequiredService<IOptions<RabbitMQConfig>>();
            var connectionFactory = new ConnectionFactory
            {
                Uri = new Uri(rabbitMQConfig.Value.ConnectionUri)
            };
            return connectionFactory.CreateConnection();
        }

        private static IModel CreateChannel(IServiceProvider serviceProvider) =>
            serviceProvider.GetRequiredService<IConnection>().CreateModel();
    }
}
