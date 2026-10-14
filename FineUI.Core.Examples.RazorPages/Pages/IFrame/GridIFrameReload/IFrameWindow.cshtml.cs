using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.IFrame.GridIFrameReload
{
    public class IFrameWindowModel : BaseThirdPartyEditorModel
    {
        public void OnGet()
        {

        }

        public IActionResult OnPostBtnUpdateParentGrid_Click()
        {
            // 1. 这里放置保存窗体中数据的逻辑

            // 2. 不关闭窗体，直接回发父窗体
            ActiveWindow.InvokeFunction("doCustomPostBack", "参数 - " + DateTime.Now.Millisecond);


            return UIHelper.Result();
        }

    }
}