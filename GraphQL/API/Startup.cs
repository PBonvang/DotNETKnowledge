using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Common;
using API.DataLoaders;
using API.Frameworks;
using API.Types;
using DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDataAccessDependencies();
            services
                .AddGraphQLServer()
                .AddQueryType(t => t.Name(RequestTypes.Query))
                    .AddTypeExtension<FrameworkQueries>()
                .AddMutationType(d => d.Name(RequestTypes.Mutation))
                    .AddTypeExtension<FrameworkMutations>()
                .AddType<FrameworkType>()
                .AddType<FeatureType>()
                .AddType<UserType>()
                .EnableRelaySupport()
                .AddDataLoader<FrameworkByIdDataLoader>()
                .AddDataLoader<FeatureByIdDataLoader>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });
        }
    }
}
