using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.IFrame
{
    public class IFrameCloseAllModel : BaseModel
    {
        public void OnGet()
        {

        }



        public IActionResult OnPostWindow1_Close()
        {
            UIHelper.Label("labResult").Text("Window1 关闭了，时间：" + DateTime.Now.ToLongTimeString());

            return UIHelper.Result();
        }

        public IActionResult OnPostWindow2_Close()
        {
            UIHelper.Label("labResult").Text("Window2 关闭了，时间：" + DateTime.Now.ToLongTimeString());

            return UIHelper.Result();
        }


        


    }
}