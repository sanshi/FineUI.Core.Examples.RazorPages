using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Toolbar
{
    public class ToolbarIFrameModel : PageBase
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostButton3_Click()
        {
            global::FineUI.Core.PageContext.InvokeFunction("updateIFrameUrl", Url.Content("~/Basic/Login"));

            return UIHelper.Result();
        }
        
    }
}