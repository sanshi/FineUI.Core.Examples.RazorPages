using Microsoft.AspNetCore.Mvc;

namespace FineUI.Core.Examples.RazorPages.Pages.Form
{
    public class DropDownListAssignmentOrderModel : PageBase
    {
        public IActionResult OnPostBtnValueThenText_Click()
        {
            var list = UIHelper.DropDownList("DropDownList2");
            list.ClearSelection();
            list.SelectedValue("a");
            list.Text("自定义输入");
            UIHelper.Label("labResult").Text("赋值动作已发送");
            return UIHelper.Result();
        }

        public IActionResult OnPostBtnTextThenValue_Click()
        {
            var list = UIHelper.DropDownList("DropDownList2");
            list.ClearSelection();
            list.Text("自定义输入");
            list.SelectedValue("a");
            UIHelper.Label("labResult").Text("赋值动作已发送");
            return UIHelper.Result();
        }

        public IActionResult OnPostBtnReadDropDownList_Click(string selection)
        {
            UIHelper.Label("labResult").Text(selection);
            return UIHelper.Result();
        }

    }
}
