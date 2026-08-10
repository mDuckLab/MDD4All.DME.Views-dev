using MDD4All.DME.ViewModels.DataManager;
using Microsoft.AspNetCore.Components;

namespace MDD4All.DME.Views.DataManager
{
    public partial class StatusBarView
    {
        [Parameter]
        public DataManagerViewModel DataContext { get; set; } = null!;
    }
}