using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Toolbar
{
    public class ToolbarIFrameModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostButton3_Click()
        {
            RegisterStartupScript(String.Format("updateIFrameUrl('{0}');", Url.Content("~/Basic/Login")));

            return UIHelper.Result();
        }
        
    }
}