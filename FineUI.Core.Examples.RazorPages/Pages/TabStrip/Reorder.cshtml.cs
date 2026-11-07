using Microsoft.AspNetCore.Mvc;

namespace FineUI.Core.Examples.RazorPages.Pages.TabStrip
{
    public class ReorderModel : PageBase
    {
        public IActionResult OnPostOpenFirst()
        {
            UIHelper.TabStrip("TabStrip1").ActiveTabIndex(0);
            return UIHelper.Result();
        }

        public IActionResult OnPostOpenHome()
        {
            UIHelper.TabStrip("TabStrip1").ActivateTab("tabHome");
            return UIHelper.Result();
        }
    }
}
