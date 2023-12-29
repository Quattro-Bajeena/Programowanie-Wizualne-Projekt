using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using OleszekMowinski.ProjectApp.MAUI.ViewModels;
using OleszekMowinski.ProjectApp.MAUI.Views;
using OleszekMowinski.ProjectApp.BLC;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using Syncfusion.Maui.Core.Hosting;

namespace OleszekMowinski.ProjectApp.MAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureSyncfusionCore()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddTransient<MainPage>();

            var a = Assembly.GetExecutingAssembly();
            using var stream = a.GetManifestResourceStream("OleszekMowinski.ProjectApp.MAUI.appsettings.json");

            var config = new ConfigurationBuilder()
                .AddJsonStream(stream)
                .Build();


            builder.Configuration.AddConfiguration(config);

            builder.Services.AddTransient<AirplaneListPage>();
            builder.Services.AddTransient<AirplaneListViewModel>();
            builder.Services.AddTransient<ManageAirplanePage>();
            builder.Services.AddTransient<ManageAirplaneViewModel>();
            builder.Services.AddTransient<AirplaneDetailsPage>();
            builder.Services.AddTransient<AirplaneDetailsViewModel>();
            builder.Services.AddSingleton(
                serviceProvider => new BuisnessLogicComponent(serviceProvider.GetService<IConfiguration>().GetValue<string>("DAOLibraryName"))
                );

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
