using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OleszekMowinski.ProjectApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OleszekMowinski.ProjectApp.MAUI.ViewModels
{
    public partial class ManufacturerDetailsViewModel : ObservableObject, IQueryAttributable
    {
        [ObservableProperty]
        IManufacturer _manufacturer;

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Manufacturer = query["ManufacturerDetails"] as IManufacturer;
        }

        [RelayCommand]
        public async Task Home()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
