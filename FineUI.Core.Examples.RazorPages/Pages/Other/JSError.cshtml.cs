using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Other
{
    public class JSErrorModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostButton4_Click()
        {
            RegisterStartupScript("test();");

            return UIHelper.Result();
        }

    }
}