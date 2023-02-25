using Microsoft.Extensions.DependencyInjection;
using TransfloTask.Data.Repositories;

namespace TransfloTask.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddData(this IServiceCollection services)
        {
            services.AddScoped<IDriverRepository, DriverRepository>();
            return services;
        }
    }
}