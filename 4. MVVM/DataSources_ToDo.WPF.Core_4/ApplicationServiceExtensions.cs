using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDo.WPF.Core.Options;
using ToDo.WPF.Core.Repository;

namespace ToDo.WPF.Core
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<RepositoryConfiguration>(configuration.GetSection("Repository"));
            services.AddScoped<IToDoItemsRepository, DapperToDoItemsRepository>();

            return services;
        }
    }
}
