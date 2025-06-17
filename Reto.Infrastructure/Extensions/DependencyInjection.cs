using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Reto.Domain.Interfaces;
using Reto.Infrastructure.Contexts;
using Reto.Infrastructure.Implements;
using Reto.Infrastructure.Persistence.Interceptors;
using Reto.Infrastructure.Persistence.Repositories;
using Reto.Shared;

namespace Reto.Infrastructure.Extensions
{
    public static class InfrastructureExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<RZConfig>(
                configuration.GetSection("RZConfig"));

            services.AddScoped<AuditableEntitySaveChangesInterceptor>();

            services.AddDbContext<RetoDbContext>((provider, options) =>
            {
                var interceptor = provider.GetRequiredService<AuditableEntitySaveChangesInterceptor>();
                options.UseSqlServer(configuration.GetConnectionString("WriteDb"));
                options.AddInterceptors(interceptor);
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddMemoryCache();
            services.AddSingleton<IStatusCache, StatusCache>();
            services.AddHttpClient<IHttpRequester, HttpRequester>();
            services.AddScoped<IDiscountService, DiscountService>();

            return services;
        }
    }
}
