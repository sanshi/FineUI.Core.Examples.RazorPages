using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.IFrame
{
    public class ButtonIFrameModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostWindow1_Close()
        {
            ShowNotify("Window1 被关闭了！");

            return UIHelper.Result();
        }

        public IActionResult OnPostWindow2_Close()
        {
            ShowNotify("Window2 被关闭了！");

            return UIHelper.Result();
        }

    }
}