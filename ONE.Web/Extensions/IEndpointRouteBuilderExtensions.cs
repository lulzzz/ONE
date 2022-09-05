using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Orleans;
using OrleansDashboard;
using System;

namespace ONE.Web.Extensions
{
    public static class IEndpointRouteBuilderExtensions
    {
        public static IEndpointConventionBuilder MapOrleansDashboard(this IEndpointRouteBuilder endpoints, string path, DashboardOptions? options = null)
        {
            if (endpoints == null)
            {
                throw new ArgumentNullException(nameof(endpoints));
            }

            return endpoints.MapMiddleware(path, app => app.UseOrleansDashboard(options));
        }

        public static IEndpointConventionBuilder MapWhenMiddleware(this IEndpointRouteBuilder endpoints, string path, Action<IApplicationBuilder> app)
        {
            if (endpoints == null)
            {
                throw new ArgumentNullException(nameof(endpoints));
            }

            var pipeline = endpoints.CreateApplicationBuilder()
                                       .MapWhen(ctx => ctx.Request.Path.StartsWithSegments(path, StringComparison.OrdinalIgnoreCase), app)
                                       .Build();

            // map the endpoint
            return endpoints.Map(path + "/{**path}", pipeline);
        }

        public static IEndpointConventionBuilder MapMiddleware(this IEndpointRouteBuilder endpoints, string path, Action<IApplicationBuilder> app)
        {
            if (endpoints == null)
            {
                throw new ArgumentNullException(nameof(endpoints));
            }

            var pipeline = endpoints.CreateApplicationBuilder()
                                       .Map(path, app)
                                       .Build();

            // map the endpoint
            return endpoints.Map(path + "/{**path}", pipeline);
        }
    }
}
