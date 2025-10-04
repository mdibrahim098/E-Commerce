using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace OrderingInfrastrueture
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddInfrastructureServices
            (this IServiceCollection services, IConfiguration configuration)
        {

            var configurationString = configuration.GetConnectionString("Database");

            services.AddDbContext<ApplicationDbContext>(options =>
                     options.UseSqlServer(configurationString));


            return services;

        }
    }
 }
