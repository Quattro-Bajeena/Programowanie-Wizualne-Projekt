using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OleszekMowinski.ProjectApp.BLC;
using OleszekMowinski.ProjectApp.Core;
using OleszekMowinski.ProjectApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OleszekMowinski.ProjectApp.MAUI.ViewModels
{
    //[QueryProperty(nameof(EditedAirplane), "EditedAirplane")]
    public partial class AirplaneManageViewModel : ObservableObject, IQueryAttributable
    {
        private readonly BuisnessLogicComponent _blc;
        [ObservableProperty]
        IAirplane? _editedAirplane;

        [ObservableProperty]
        private string _title;

        [ObservableProperty]
        private Guid? _id;

        [ObservableProperty]
        string _name;

        [ObservableProperty]
        DateTime _introduction;

        [ObservableProperty]
        int _weight;

        [ObservableProperty]
        AirplaneStatus _status;

        [ObservableProperty]
        IManufacturer _manufacturer;

        public IReadOnlyList<string> AllAirplaneStatuses { get; } = Enum.GetNames(typeof(AirplaneStatus));
        public IReadOnlyList<IManufacturer> AllManufacturers { get; }

        public AirplaneManageViewModel(BuisnessLogicComponent buisnessLogicComponent)
        {
            Title = "Add new Airplane";
            _blc = buisnessLogicComponent;
            AllManufacturers = _blc.GetManufacturers().ToList();
            Manufacturer = AllManufacturers.FirstOrDefault(); 
        }

        [RelayCommand]
        private async Task SaveAirplane()
        {
            IToast toast;
            if ( Id != null)
            {
                // Update
                _blc.EditAirplane((Guid)Id, Name, Introduction, Weight, Status, Manufacturer.Id);
                toast = Toast.Make("Updated Airplane");
            }
            else
            {
                // Add new
                _blc.CreateNewAirplane(Name, Introduction, Weight, Status, Manufacturer.Id);
                toast = Toast.Make("New Airplane Created");
            }

            await toast.Show(new CancellationTokenSource().Token);
            await Shell.Current.GoToAsync("..");
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            var found = query.TryGetValue("EditedAirplane", out object editedAirplane);
            if (found)
            {
                EditedAirplane = editedAirplane as IAirplane;
                Title = "Edit Airplane";
                Id = EditedAirplane.Id;
                Name = EditedAirplane.Name;
                Introduction = EditedAirplane.Introduction;
                Weight = EditedAirplane.Weight;
                Status = EditedAirplane.Status;
                Manufacturer = EditedAirplane.Manufacturer;
            }
        }
    }
}
