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
    //[QueryProperty(nameof(Airplane), "AirplaneDetails")]
    public partial class AirplaneDetailsViewModel : ObservableObject, IQueryAttributable
    {
        [ObservableProperty]
        IAirplane _airplane;

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Airplane = query["AirplaneDetails"] as IAirplane;
        }

        [RelayCommand]
        public async Task Home()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
