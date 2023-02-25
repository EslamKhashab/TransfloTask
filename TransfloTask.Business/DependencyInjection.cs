using Microsoft.Extensions.DependencyInjection;
using TransfloTask.Business.Services.DriverService;

namespace TransfloTask.Business
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusiness(this IServiceCollection services)
        {
            services.AddTransient<IDriverService, DriverService>();
            return services;
        }
    }
}