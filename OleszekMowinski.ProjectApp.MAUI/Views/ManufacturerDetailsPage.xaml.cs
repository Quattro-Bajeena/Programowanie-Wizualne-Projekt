using OleszekMowinski.ProjectApp.MAUI.ViewModels;

namespace OleszekMowinski.ProjectApp.MAUI.Views;

public partial class ManufacturerDetailsPage : ContentPage
{
	public ManufacturerDetailsPage(ManufacturerDetailsViewModel manufacturerDetailsViewModel)
	{
		InitializeComponent();
		BindingContext = manufacturerDetailsViewModel;

    }
}