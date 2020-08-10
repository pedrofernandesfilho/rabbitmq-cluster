using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using System;

namespace RabbitMQCluster.WebApi
{
    static class RabbitMQExtensions
    {
        public static void AddRabbitMQ(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            services.AddSingleton<IConnection>(CreateConnection());
            services.AddSingleton<IModel>(CreateChannel(serviceProvider));
        }

        private static IConnection CreateConnection()
        {
            var connectionFactory = new ConnectionFactory
            {
                Uri = new Uri("amqp://localhost:5673")
            };

            return connectionFactory.CreateConnection();
        }

        private static IModel CreateChannel(ServiceProvider serviceProvider) =>
            serviceProvider.GetRequiredService<IConnection>().CreateModel();
    }
}
