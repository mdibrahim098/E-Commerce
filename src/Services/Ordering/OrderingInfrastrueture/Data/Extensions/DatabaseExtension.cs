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

            await SeedAsync(context);
        }
        private static async Task SeedAsync(ApplicationDbContext context)
        {
            await SeedCustomersAsync(context);
            //await SeedProductAsync(context);
            //await SeedOrderAndItemsAsync(context);
        }
        private static async Task SeedCustomersAsync(ApplicationDbContext context)
        {
            if(!await context.Customers.AnyAsync())
            {
                await context.Customers.AddRangeAsync(InitialData.Customers);
                await context.SaveChangesAsync();
            }
        }


    }
}
