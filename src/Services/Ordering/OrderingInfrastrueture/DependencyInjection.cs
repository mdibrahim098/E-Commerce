using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace OrderingInfrastrueture
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
               IConfiguration configuration)
        {

            var configurationString = configuration.GetConnectionString("Dtabase");

            //services.AddDbContext<OrderingContext>(options =>
            //{
            //    options.UseSqlServer(configurationString,
            //        sqlOptions => sqlOptions.MigrationsAssembly(typeof(OrderingContext).Assembly.FullName));
            //});

            return services;

        }
    }
 }
