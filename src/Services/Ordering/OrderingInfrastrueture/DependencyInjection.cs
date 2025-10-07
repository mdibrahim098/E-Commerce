using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderingApplication.Data;
using OrderingInfrastrueture.Data.Interceptors;
namespace OrderingInfrastrueture
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddInfrastructureServices
            (this IServiceCollection services, IConfiguration configuration)
        {

            var configurationString = configuration.GetConnectionString("Database");

            services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
            services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventInterceptor>();

            services.AddDbContext<ApplicationDbContext>((sp,options) =>
            {
                options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
                options.UseSqlServer(configurationString);
            });

            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

            return services;

        }
    }
 }
