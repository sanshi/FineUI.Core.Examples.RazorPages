using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.TabStrip
{
    public class CloseMenuIconFontCSSModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostBtnShowInServer_Click()
        {
            UIHelper.Tab("Tab3").Show();

            return UIHelper.Result();
        }


        public IActionResult OnPostBtnHideInServer_Click()
        {
            UIHelper.Tab("Tab3").Hide();

            return UIHelper.Result();
        }

    }
}