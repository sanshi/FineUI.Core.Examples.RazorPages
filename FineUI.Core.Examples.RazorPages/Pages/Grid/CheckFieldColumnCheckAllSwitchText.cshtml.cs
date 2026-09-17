using Microsoft.AspNetCore.Mvc;

namespace FineUI.Core.Examples.RazorPages.Pages.Grid
{
    public class CheckFieldColumnCheckAllSwitchTextModel : BaseModel
    {
        public void OnGet()
        {

        }



        public IActionResult OnPostBtnSubmit_Click()
        {


            return UIHelper.Result();
        }

    }
}
