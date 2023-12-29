using OleszekMowinski.ProjectApp.MAUI.ViewModels;

namespace OleszekMowinski.ProjectApp.MAUI.Views;

public partial class ManufacturerManagePage : ContentPage
{
	public ManufacturerManagePage(ManufacturerManageViewModel manufacturerManageViewModel)
	{
		InitializeComponent();
		BindingContext = manufacturerManageViewModel;
	}
}