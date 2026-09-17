using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Message.AlertDownloadHideIFrame
{
    public class IFrameWindowModel : BaseModel
    {
        public void OnGet()
        {

        }


        public IActionResult OnPostBtnOperation_Click()
        {
            // 不要在这里调用F.confirm，因为当前页面要被关闭，因此F.confirm的回调函数不能正确执行
            RegisterStartupScript(ActiveWindow.GetHideReference() + "parent.showConfirm();");

            return UIHelper.Result();
        }

    }
}