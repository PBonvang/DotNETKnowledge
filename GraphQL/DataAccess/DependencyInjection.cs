using DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAccessDependencies(this IServiceCollection services)
        {
            services.AddDbContext<EntityContext>();
            services.RegisterRepositories();
            return services;
        }

        private static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IFrameworkRepository,FrameworkRepository>();
            services.AddScoped<IFeatureRepository,FeatureRepository>();
            services.AddScoped<IUserRepository,UserRepository>();
            return services;
        }
    }
}