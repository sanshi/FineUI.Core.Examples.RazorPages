using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.IFrame.IFrameIFrame
{
    public class IFrameWindowModel : BaseModel
    {
        public void OnGet()
        {

        }


        public IActionResult OnPostWindow3_Close()
        {
            UIHelper.Label("labResult").Text("Window3 关闭了，时间：" + DateTime.Now.ToLongTimeString());

            return UIHelper.Result();
        }

        public IActionResult OnPostWindow4_Close()
        {
            UIHelper.Label("labResult").Text("Window4 关闭了，时间：" + DateTime.Now.ToLongTimeString());

            return UIHelper.Result();
        }

    }
}