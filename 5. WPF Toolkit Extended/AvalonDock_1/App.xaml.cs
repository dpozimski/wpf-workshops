using Microsoft.Extensions.DependencyInjection;
using System;
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

        protected override void OnStartup(StartupEventArgs e)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            ServiceProvider = serviceCollection.BuildServiceProvider();

            var mainWindow = ServiceProvider.GetRequiredService<ShellView>();
            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication();

            services.AddTransient<StatsViewModel>();
            services.AddTransient<StatsView>();
            
            services.AddTransient<TodosViewModel>();
            services.AddTransient<TodosView>();

            services.AddTransient<ShellView>();
            services.AddTransient<ShellViewModel>();

            services.AddTransient<TodoNotesView>();
            services.AddTransient<TodoNotesViewModel>();
        }
    }
}
