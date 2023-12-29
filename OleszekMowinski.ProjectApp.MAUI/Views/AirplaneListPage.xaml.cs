using OleszekMowinski.ProjectApp.MAUI.ViewModels;

namespace OleszekMowinski.ProjectApp.MAUI.Views;

public partial class AirplaneListPage : ContentPage
{
	private readonly AirplaneListViewModel _airplaneListViewModel;
	public AirplaneListPage(AirplaneListViewModel airplaneListViewModel)
	{
		InitializeComponent();
		BindingContext = airplaneListViewModel;
		_airplaneListViewModel = airplaneListViewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
		_airplaneListViewModel.ReloadAirplanes();
    }
}