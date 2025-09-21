namespace OrderingApi
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            // app.Carter();

            return services;
        }

        public static WebApplication UseApiServices(this WebApplication app)
        {
            // app.Carter();

            return app;
        }

    }
}
