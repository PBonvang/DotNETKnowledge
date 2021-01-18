using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Infrastructure
{
    public static class PipeRegistration
    {
        public static IServiceCollection ConfigureMediatRPipeLine(this IServiceCollection services)
        {
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(RequestTrackingPipe<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(UserIdPipe<,>));

            return services;
        }
    }
}