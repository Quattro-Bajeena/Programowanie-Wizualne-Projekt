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
    public partial class AirplaneListViewModel : CommunityToolkit.Mvvm.ComponentModel.ObservableObject
    {
        private readonly BuisnessLogicComponent _blc;

        public ObservableRangeCollection<IAirplane> Airplanes { get; } = [];
        public IReadOnlyList<string> AllAirplaneStatuses { get; } = Enum.GetNames(typeof(AirplaneStatus));

        [ObservableProperty]
        AirplaneStatus _filterStatus;

        public AirplaneListViewModel(BuisnessLogicComponent buisnessLogicComponent)
        {
            _blc = buisnessLogicComponent;
            ReloadAirplanes();
        }

        public void ReloadAirplanes()
        {
            Airplanes.ReplaceRange(_blc.GetAirplanes().ToList());
        }

        [RelayCommand]
        void FilterAirplanes()
        {
            var filter = new AirplaneFilter
            {
                Status = FilterStatus
            };
            var filteredAirplanes = _blc.GetFilteredAirplanes(filter);
            Airplanes.ReplaceRange(filteredAirplanes);
        }

        [RelayCommand]
        async Task GoToAddPlane()
        {
            await Shell.Current.GoToAsync(nameof(ManageAirplanePage));
        }

        [RelayCommand]
        async Task DisplayActionSheet(IAirplane airplane)
        {
            if(airplane is null)
            {
                return;
            }

            var response = await Shell.Current.DisplayActionSheet("Select Option", "Ok", null,"View", "Edit", "Delete");
            if(response == "View")
            {
                var navigationParameter = new Dictionary<string, object>
                {
                    { "AirplaneDetails", airplane }
                };
                await Shell.Current.GoToAsync(nameof(AirplaneDetailsPage), navigationParameter);
            }
            else if(response == "Edit")
            {
                var navigationParameter = new Dictionary<string, object>
                {
                    { "EditedAirplane", airplane }
                };
                await Shell.Current.GoToAsync(nameof(ManageAirplanePage), navigationParameter);
                ReloadAirplanes();
            }
            else if(response == "Delete")
            {
                _blc.DeleteAirplane(airplane.Id);
                await Toast.Make("Deleted Airplane").Show();
                ReloadAirplanes();
            }

        }
    }
}
