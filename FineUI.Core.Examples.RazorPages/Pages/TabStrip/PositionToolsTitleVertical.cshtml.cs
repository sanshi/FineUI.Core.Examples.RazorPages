using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FineUI.Core.Examples.RazorPages.Pages.TabStrip
{
    public class PositionToolsTitleVerticalModel : PageBase
    {
        public void OnGet()
        {

        }



        public IActionResult OnPostBtnSubmit_Click(IFormCollection values)
        {
            ShowNotify(values);

            return UIHelper.Result();
        }

    }
}
