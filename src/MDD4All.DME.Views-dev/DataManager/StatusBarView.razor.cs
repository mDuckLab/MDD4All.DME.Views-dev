using MDD4All.DME.ViewModels.DataManager;
using Microsoft.AspNetCore.Components;
using System;
using System.ComponentModel;

namespace MDD4All.DME.Views.DataManager
{
    public partial class StatusBarView : ComponentBase, IDisposable
    {
        [Parameter]
        public DataManagerFileViewModel DataContext { get; set; } = null!;

        // Without this the bar only refreshed when something else happened to trigger a render,
        // so a failed load was written into StatusText and never appeared. Opening a file runs
        // on a queued callback rather than inside a render cycle, hence InvokeAsync.
        protected override void OnInitialized()
        {
            DataContext.PropertyChanged += this.OnDataFilePropertyChanged;
        }

        public void Dispose()
        {
            DataContext.PropertyChanged -= this.OnDataFilePropertyChanged;
        }

        private void OnDataFilePropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            this.InvokeAsync(this.StateHasChanged);
        }

        private bool HasError
        {
            get
            {
                bool result = (DataContext.LoadErrorMessage.Length > 0);

                return result;
            }
        }
    }
}
