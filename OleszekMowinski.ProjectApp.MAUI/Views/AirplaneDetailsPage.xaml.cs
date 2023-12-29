using OleszekMowinski.ProjectApp.MAUI.ViewModels;

namespace OleszekMowinski.ProjectApp.MAUI.Views;

public partial class AirplaneDetailsPage : ContentPage
{

	public AirplaneDetailsPage(AirplaneDetailsViewModel airplaneDetailsViewModel)
	{
		InitializeComponent();
		BindingContext = airplaneDetailsViewModel;
	}
}