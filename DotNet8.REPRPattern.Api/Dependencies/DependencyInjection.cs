using DotNet8.REPRPattern.Api.Db;
using DotNet8.REPRPattern.Api.Extensions;
using Microsoft.EntityFrameworkCore;

namespace DotNet8.REPRPattern.Api.Dependencies
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, WebApplicationBuilder builder)
        {
            return services.AddDbContextService(builder).AddMediatRService();
        }

        private static IServiceCollection AddDbContextService(this  IServiceCollection services, WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
                opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            }, ServiceLifetime.Transient, ServiceLifetime.Transient);

            return services;
        }

        private static IServiceCollection AddMediatRService(this IServiceCollection services)
        {
            return services.AddMediatR(cf =>
                cf.RegisterServicesFromAssembly(typeof(Extension).Assembly)
            );
        }
    }
}
