using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmHelpers;
using OleszekMowinski.ProjectApp.BLC;
using OleszekMowinski.ProjectApp.Core;
using OleszekMowinski.ProjectApp.Interfaces;
using OleszekMowinski.ProjectApp.MAUI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OleszekMowinski.ProjectApp.MAUI.ViewModels
{
    public partial class ManufacturerListViewModel : CommunityToolkit.Mvvm.ComponentModel.ObservableObject
    {
        private readonly BuisnessLogicComponent _blc;

        public ObservableRangeCollection<IManufacturer> Manufacturers { get; } = [];

        [ObservableProperty]
        AirplaneStatus _filterStatus;

        public ManufacturerListViewModel(BuisnessLogicComponent buisnessLogicComponent)
        {
            _blc = buisnessLogicComponent;
            ReloadManufacturers();
        }

        public void ReloadManufacturers()
        {
            Manufacturers.ReplaceRange(_blc.GetManufacturers().ToList());
        }

        [RelayCommand]
        async Task GoToAddManufacturer()
        {
            await Shell.Current.GoToAsync(nameof(ManufacturerManagePage));
        }

        [RelayCommand]
        async Task DisplayActionSheet(IManufacturer manufacturer)
        {
            if (manufacturer is null)
            {
                return;
            }

            var response = await Shell.Current.DisplayActionSheet("Select Option", "Ok", null, "View", "Edit", "Delete");
            if (response == "View")
            {
                var navigationParameter = new Dictionary<string, object>
                {
                    { "ManufacturerDetails", manufacturer }
                };
                await Shell.Current.GoToAsync(nameof(ManufacturerDetailsPage), navigationParameter);
            }
            else if (response == "Edit")
            {
                var navigationParameter = new Dictionary<string, object>
                {
                    { "EditedManufacturer", manufacturer }
                };
                await Shell.Current.GoToAsync(nameof(ManufacturerManagePage), navigationParameter);
                ReloadManufacturers();
            }
            else if (response == "Delete")
            {
                _blc.DeleteAirplane(manufacturer.Id);
                await Toast.Make("Deleted Airplane").Show();
                ReloadManufacturers();
            }

        }
    }
}
