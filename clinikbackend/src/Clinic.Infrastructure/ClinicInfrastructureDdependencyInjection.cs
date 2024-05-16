using Clinic.Application.Abstractions;
using Clinic.Infrastructure.Persistance;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Proxies;
using Microsoft.EntityFrameworkCore;
namespace Clinic.Infrastructure
{
    public static class ClinicInfrastructureDdependencyInjection
    {
        public static IServiceCollection AddClinicInfrastructureDdependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IClinincDbContext, ClinincDbContext>(options =>
            {
                options
                    .UseLazyLoadingProxies()
                        .UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });

            return services;
        }
    }
}
