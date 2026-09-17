using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.GridPaging
{
    public class PageItemsRowExpanderModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostBtnShowRowExpanders_Click(bool expanded)
        {
            var grid1 = UIHelper.Grid("Grid1");
            if (expanded)
            {
                grid1.CollapseRowExpanders();
            }
            else
            {
                grid1.ExpandRowExpanders();
            }

            return UIHelper.Result();
        }

    }
}