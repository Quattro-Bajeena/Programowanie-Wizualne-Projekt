using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OleszekMowinski.ProjectApp.BLC;
using OleszekMowinski.ProjectApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OleszekMowinski.ProjectApp.MAUI.ViewModels
{
    public partial class ManufacturerManageViewModel : ObservableObject, IQueryAttributable
    {
        private readonly BuisnessLogicComponent _blc;
        [ObservableProperty]
        IManufacturer? _editedManufacturer;

        [ObservableProperty]
        private string _title;

        [ObservableProperty]
        private Guid? _id;

        [ObservableProperty]
        string _name;

        [ObservableProperty]
        DateTime _founded;

        [ObservableProperty]
        string _headquaters;

        [ObservableProperty]
        string _president;


        public ManufacturerManageViewModel(BuisnessLogicComponent buisnessLogicComponent)
        {
            Title = "Add new Manufacturer";
            _blc = buisnessLogicComponent;
        }

        [RelayCommand]
        private async Task SaveAirplane()
        {
            IToast toast;
            if (Id != null)
            {
                // Update
                _blc.EditManufacturer((Guid)Id, Name, Founded, Headquaters, President);
                toast = Toast.Make("Updated Manufacturer");
            }
            else
            {
                // Add new
                _blc.CreateNewManufacturer(Name, Founded, Headquaters, President);
                toast = Toast.Make("New Manufacturer Created");
            }

            await toast.Show(new CancellationTokenSource().Token);
            await Shell.Current.GoToAsync("..");
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            var found = query.TryGetValue("EditedManufacturer", out object editedManufacturer);
            if (found)
            {
                EditedManufacturer = editedManufacturer as IManufacturer;
                Title = "Edit Manufacturer";
                Id = EditedManufacturer.Id;
                Name = EditedManufacturer.Name;
                Founded = EditedManufacturer.Founded;
                Headquaters = EditedManufacturer.Headquarters;
                President = EditedManufacturer.President;
            }
        }
    }
}
