using MDD4All.DME.ViewModels.DataManager;
using Microsoft.AspNetCore.Components;

namespace MDD4All.DME.Views.Dialogs
{
    public partial class UnsavedChangesDialog
    {
        [Inject]
        public DataManagerFileViewModel DataFile { get; set; } = null!;

        // The command that was interrupted waits on this answer and either runs or is dropped.
        private void OnDialogClose(bool confirmed)
        {
            DataFile.AnswerUnsavedChanges(confirmed);
        }
    }
}
