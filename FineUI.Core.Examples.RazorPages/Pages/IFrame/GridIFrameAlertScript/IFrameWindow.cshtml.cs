using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.IFrame.GridIFrameAlertScript
{
    public class IFrameWindowModel : BaseThirdPartyEditorModel
    {
        public void OnGet()
        {

        }

        public IActionResult OnPostBtnUpdateParentGrid_Click()
        {
            // 1. 这里放置保存窗体中数据的逻辑

            // 2. 先弹出提示对话框，再回发父窗体
            // 2. 如果无需传递参数，可以将 GetHideExecuteScriptReference 改为 GetHidePostBackReference 即可！
            new Alert
            {
                Message = "保存成功！",
                MessageBoxIcon = MessageBoxIcon.Success,
                Target = Target.Top,
                OkCommand = ActiveWindow.HideInvokeFunctionCommand("doCustomPostBack", "参数 - " + DateTime.Now.Millisecond)
            }.Show();


            return UIHelper.Result();
        }

    }
}