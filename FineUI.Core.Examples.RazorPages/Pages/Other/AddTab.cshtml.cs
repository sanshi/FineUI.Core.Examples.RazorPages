using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Other
{
    public class AddTabModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostButton3_Click()
        {
            RegisterStartupScript("onCloseActiveTabClick();");

            return UIHelper.Result();
        }

    }
}