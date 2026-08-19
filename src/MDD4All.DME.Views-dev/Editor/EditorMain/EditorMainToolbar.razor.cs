using MDD4All.DME.DataAccess.DataModels;
using MDD4All.DME.ViewModels.DataManager;
using Microsoft.AspNetCore.Components;
using System;

namespace MDD4All.DME.Views.Editor
{
    public partial class EditorMainToolbar
    {
        [Inject]
        public MainViewModel Navigation { get; set; } = null!;

        [Inject]
        public DataManagerFileViewModel DataFile { get; set; } = null!;

        // The data models compiled into the solution. Takes the place of picking a DLL.
        [Inject]
        public DataModelCatalog Catalog { get; set; } = null!;

        private void CreateNew(Type dataModelType)
        {
            DataFile.NewDataFileCommand.Execute(dataModelType);
        }
    }
}
