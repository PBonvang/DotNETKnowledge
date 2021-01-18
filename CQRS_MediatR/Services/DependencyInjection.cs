using System.Reflection;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServicesDependencies(this IServiceCollection services)
        {
            var executingAssembly = Assembly.GetExecutingAssembly();

            services.AddMediatR(executingAssembly);
            services.AddAutoMapper(executingAssembly);
            return services;
        }
    }
}