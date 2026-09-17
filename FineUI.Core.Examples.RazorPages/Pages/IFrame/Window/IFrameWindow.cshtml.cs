using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.IFrame.Window
{
    public class IFrameWindowModel : BaseModel
    {
        public void OnGet()
        {

        }

        public IActionResult OnPostBtnClosePostBack_Click()
        {
            // 首先保存数据

            // 然后关闭本窗体
            var panel1 = UIHelper.Panel("Panel1");
            RegisterStartupScript(panel1.GetClearDirtyReference() + ActiveWindow.GetHideReference());

            return UIHelper.Result();
        }

    }
}