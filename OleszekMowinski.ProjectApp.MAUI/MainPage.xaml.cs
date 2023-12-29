using OleszekMowinski.ProjectApp.MAUI.Views;

namespace OleszekMowinski.ProjectApp.MAUI
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            
        }

        private void AirplaneButtonClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync(nameof(AirplaneListPage));
        }

        private void ManufacturersButtonClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync(nameof(ManufacturerListPage));
        }
    }

}
