using Microsoft.Extensions.DependencyInjection;

namespace DataAccess
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAccessDependencies(this IServiceCollection services)
        {
            services.AddDbContext<EntityContext>();
            return services;
        }
    }
}