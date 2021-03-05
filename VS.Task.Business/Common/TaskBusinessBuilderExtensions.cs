using Microsoft.Extensions.DependencyInjection;
using VS.Task.Business.Services;
using VS.Task.Business.Services.Contracts;

namespace VS.Task.Business.Common
{
    public static class TaskBusinessBuilderExtensions
    {
        public static IServiceCollection BuildTaskBusinessService(this IServiceCollection services)
        {
            services.AddScoped<IProviderService, ProviderService>();
            services.AddScoped<IGroupService, GroupService>();

            return services;
        }
    }
}
