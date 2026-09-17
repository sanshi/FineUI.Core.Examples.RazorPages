using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Panel
{
    public class CollapseModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostPanel1_CollapseExpand(bool collapsed)
        {
            ShowNotify(String.Format("面板一处于{0}状态", !collapsed ? "展开" : "折叠"));

            return UIHelper.Result();
        }

        public IActionResult OnPostPanel2_CollapseExpand(bool collapsed)
        {
            ShowNotify(String.Format("面板二处于{0}状态", !collapsed ? "展开" : "折叠"));

            return UIHelper.Result();
        }

    }
}