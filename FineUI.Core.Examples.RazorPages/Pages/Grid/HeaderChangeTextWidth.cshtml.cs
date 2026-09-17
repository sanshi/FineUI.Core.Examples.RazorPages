using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Grid
{
    public class HeaderChangeTextWidthModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostButton1_Click()
        {
            RegisterStartupScript(String.Format("changeColumnTitleAndWidth('入学年份（已修改）', 200);"));

            return UIHelper.Result();
        }

        public IActionResult OnPostButton2_Click()
        {
            RegisterStartupScript(String.Format("changeColumnTitleAndWidth('入学年份', 120);"));

            return UIHelper.Result();
        }

    }
}