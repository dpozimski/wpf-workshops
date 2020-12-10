using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Windows;
using ToDo.WPF.Core.ViewModels;
using ToDo.WPF.Core.Views;

namespace ToDo.WPF.Core
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }
        public IConfiguration Configuration { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            ServiceProvider = serviceCollection.BuildServiceProvider();

            var mainWindow = ServiceProvider.GetRequiredService<ShellView>();
            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication(Configuration);

            services.AddTransient<StatsViewModel>();
            services.AddTransient<StatsView>();
            
            services.AddTransient<TodosViewModel>();
            services.AddTransient<TodosView>();

            services.AddTransient<ShellView>();
            services.AddTransient<ShellViewModel>();
        }
    }
}
