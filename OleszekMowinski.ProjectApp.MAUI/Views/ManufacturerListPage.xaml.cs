using OleszekMowinski.ProjectApp.MAUI.ViewModels;

namespace OleszekMowinski.ProjectApp.MAUI.Views;

public partial class ManufacturerListPage : ContentPage
{
	private readonly ManufacturerListViewModel _viewModel;
	public ManufacturerListPage(ManufacturerListViewModel manufacturerListViewModel)
	{
		InitializeComponent();
		BindingContext = manufacturerListViewModel;
		_viewModel = manufacturerListViewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.ReloadManufacturers();
    }
}