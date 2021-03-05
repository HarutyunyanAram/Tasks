using Microsoft.Extensions.DependencyInjection;
using VS.Task.Data.Repositories;
using VS.Task.Data.Repositories.Contracts;

namespace VS.Task.Data.Common
{
    public static class TaskDataBuilderExtensions
    {
        public static IServiceCollection BuildTaskDataServices(this IServiceCollection services)
        {
            services.AddScoped<IProviderRepository, ProviderRepository>();
            services.AddScoped<IGroupRepository, GroupRepository>();

            return services;
        }
    }
}
