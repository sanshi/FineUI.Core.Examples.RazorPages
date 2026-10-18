using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Message.AlertDownloadHideIFrame
{
    public class IFrameWindowModel : PageBase
    {
        public void OnGet()
        {

        }


        public IActionResult OnPostBtnOperation_Click()
        {
            // 不要在这里调用F.confirm，因为当前页面要被关闭，因此F.confirm的回调函数不能正确执行
            ActiveWindow.Hide();
            global::FineUI.Core.PageContext.InvokeParentFunction("showConfirm");

            return UIHelper.Result();
        }

    }
}