using Microsoft.AspNetCore.Mvc;

namespace FineUI.Core.Examples.RazorPages.Pages.Form
{
    public class FieldHelperTextModel : PageBase
    {
        public IActionResult OnPostUpdate()
        {
            UIHelper.TextBox("tbxEmail").HelperText("请填写部门公共邮箱，便于同事接收后续通知。");
            return UIHelper.Result();
        }

        public IActionResult OnPostClear()
        {
            UIHelper.TextBox("tbxEmail").HelperText(null);
            return UIHelper.Result();
        }

        public IActionResult OnPostRead(string helperText)
        {
            UIHelper.Label("labResult").Text(helperText);
            return UIHelper.Result();
        }
    }
}
