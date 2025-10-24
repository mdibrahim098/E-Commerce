using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BuildingBlocksMessaging.MassTransit
{
    public static class Extentions
    {
        public static IServiceCollection AddMessageBroker
            (this IServiceCollection sevices,IConfiguration configuration,
            Assembly? assembly = null)
        {

            // Implement rabbitMQ MassTransit configuration

            sevices.AddMassTransit(config =>
            {
               config.SetKebabCaseEndpointNameFormatter();

                if(assembly != null)
                {
                    config.AddConsumers(assembly);
                }

                config.UsingRabbitMq((context, configurator) =>
                {
                    configurator.Host(new Uri(configuration["MassageBroker:Host"]!), host =>
                    {
                        host.Username(configuration["MassageBroker:UserName"]);
                        host.Password(configuration["MassageBroker:Password"]);
                    });
                    configurator.ConfigureEndpoints(context);
                });


            });


            return sevices;
        }


    }
}
