using System.Configuration;
using System.Data;
using System.Windows;
using Framework.Data;
using Framework.Repositories;
using Framework.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LaundryManagement
{
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);

            ServiceProvider = services.BuildServiceProvider();

            var mainWindow = ServiceProvider.GetRequiredService<Views.MainWindow>();
            mainWindow.DataContext = ServiceProvider.GetRequiredService<ViewModels.MainViewModel>();
            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            services.AddSingleton<IConfiguration>(configuration);

            services.AddSingleton<AppDbContext>();
            services.AddSingleton<ILaundryRepository, LaundryRepository>();
            services.AddSingleton<ILaundryService, LaundryService>();

            services.AddSingleton<ViewModels.MainViewModel>();
            services.AddSingleton<Views.MainWindow>();
        }
    }
}