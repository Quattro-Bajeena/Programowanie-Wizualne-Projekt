using OleszekMowinski.ProjectApp.MAUI.Views;

namespace OleszekMowinski.ProjectApp.MAUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AirplaneListPage), typeof(AirplaneListPage));
            Routing.RegisterRoute(nameof(AirplaneManagePage), typeof(AirplaneManagePage));
            Routing.RegisterRoute(nameof(AirplaneDetailsPage), typeof(AirplaneDetailsPage));
            Routing.RegisterRoute(nameof(ManufacturerListPage), typeof(ManufacturerListPage));
            Routing.RegisterRoute(nameof(ManufacturerDetailsPage), typeof(ManufacturerDetailsPage));
            Routing.RegisterRoute(nameof(ManufacturerManagePage), typeof(ManufacturerManagePage));

        }
    }
}
