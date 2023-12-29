using OleszekMowinski.ProjectApp.MAUI.ViewModels;

namespace OleszekMowinski.ProjectApp.MAUI.Views;

public partial class AirplaneManagePage : ContentPage
{
	public AirplaneManagePage(AirplaneManageViewModel manageAirplaneViewModel)
	{
		InitializeComponent();
		BindingContext = manageAirplaneViewModel;
	}
}