using Microsoft.AspNetCore.Components;

namespace MDD4All.DME.Views.Localization
{
    // Base class for every component that shows text. Inheriting from it is the one line a
    // component needs; after that L["Some.Key"] is available.
    //
    // A base class rather than an injection per component, so that adding a text somewhere never
    // means remembering the plumbing as well.
    public abstract class LocalizedComponent : ComponentBase
    {
        [Inject]
        protected AppTextProvider L { get; set; } = null!;
    }
}
