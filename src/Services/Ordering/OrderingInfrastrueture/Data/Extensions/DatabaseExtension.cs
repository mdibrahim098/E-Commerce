using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace OrderingInfrastrueture.Data.Extensions
{
    public static class DatabaseExtension
    {
        public static async Task InitialiseDatabaseAsync( this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            context.Database.MigrateAsync().GetAwaiter().GetResult();

        }

    }
}
