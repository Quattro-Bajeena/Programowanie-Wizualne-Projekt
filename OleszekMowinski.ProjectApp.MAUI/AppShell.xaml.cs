using OleszekMowinski.ProjectApp.MAUI.Views;

namespace OleszekMowinski.ProjectApp.MAUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AirplaneListPage), typeof(AirplaneListPage));
            Routing.RegisterRoute(nameof(ManageAirplanePage), typeof(ManageAirplanePage));
            Routing.RegisterRoute(nameof(AirplaneDetailsPage), typeof(AirplaneDetailsPage));
        }
    }
}
