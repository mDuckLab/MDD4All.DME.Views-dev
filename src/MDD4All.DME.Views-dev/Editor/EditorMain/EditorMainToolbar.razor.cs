using MDD4All.DME.DataAccess.DataModels;
using MDD4All.DME.ViewModels.DataManager;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MDD4All.DME.Views.Editor
{
    public partial class EditorMainToolbar : ComponentBase, IDisposable
    {
        [Inject]
        public DataManagerFileViewModel DataFile { get; set; } = null!;

        // The data models compiled into the solution. Takes the place of picking a DLL.
        [Inject]
        public DataModelCatalog Catalog { get; set; } = null!;

        [Inject]
        public DataManagerSettingsViewModel DataSettings { get; set; } = null!;

        // Filtered down to what New can build, unless the setting says otherwise.
        private List<Type> OfferedTypes
        {
            get
            {
                List<Type> result;

                if (DataSettings.ShowAllDataModels)
                {
                    result = Catalog.AllTypes;
                }
                else
                {
                    result = Catalog.AvailableTypes;
                }

                return result;
            }
        }

        // Two things change this toolbar without anyone touching it: opening a file that names
        // its own type moves the selection, and the settings dialog decides how long the list is.
        protected override void OnInitialized()
        {
            DataFile.PropertyChanged += this.OnDataFilePropertyChanged;
            DataSettings.PropertyChanged += this.OnDataSettingsPropertyChanged;

            // Something has to be selected for New to do anything at all.
            if (DataFile.SelectedDataModel == null && Catalog.AvailableTypes.Count > 0)
            {
                DataFile.SelectedDataModel = Catalog.AvailableTypes[0];
            }
        }

        public void Dispose()
        {
            DataFile.PropertyChanged -= this.OnDataFilePropertyChanged;
            DataSettings.PropertyChanged -= this.OnDataSettingsPropertyChanged;
        }

        private void OnDataFilePropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(DataManagerFileViewModel.SelectedDataModel))
            {
                this.InvokeAsync(this.StateHasChanged);
            }
        }

        private void OnDataSettingsPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(DataManagerSettingsViewModel.ShowAllDataModels))
            {
                this.InvokeAsync(this.StateHasChanged);
            }
        }

        private string SelectedModelName
        {
            get
            {
                string result = "No data model";

                if (DataFile.SelectedDataModel != null)
                {
                    result = DataFile.SelectedDataModel.Name;
                }

                return result;
            }
        }
    }
}
