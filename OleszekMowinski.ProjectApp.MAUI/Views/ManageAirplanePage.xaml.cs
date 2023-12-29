using OleszekMowinski.ProjectApp.MAUI.ViewModels;

namespace OleszekMowinski.ProjectApp.MAUI.Views;

public partial class ManageAirplanePage : ContentPage
{
	public ManageAirplanePage(ManageAirplaneViewModel manageAirplaneViewModel)
	{
		InitializeComponent();
		BindingContext = manageAirplaneViewModel;
	}
}