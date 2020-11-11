using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using ToDo.WPF.Core.Repository;

namespace ToDo.WPF.Core
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IToDoItemsRepository, InMemoryToDoItemsRepository>();

            return services;
        }
    }
}
