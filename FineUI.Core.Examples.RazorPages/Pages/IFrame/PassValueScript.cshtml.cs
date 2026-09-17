using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.IFrame
{
    public class PassValueScriptModel : BaseModel
    {
        public void OnGet()
        {

        }

        

        public IActionResult OnPostWindow1_Close()
        {
            ShowNotify("触发了 Window1 的关闭事件！");

            return UIHelper.Result();
        }

    }
}