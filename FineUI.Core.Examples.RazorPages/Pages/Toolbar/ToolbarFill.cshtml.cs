using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Toolbar
{
    public class ToolbarFillModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostBtnHideFill1_Click(bool hidden)
        {
            var Button1 = UIHelper.Button("Button1");
            var ToolbarFill1 = UIHelper.ToolbarFill("ToolbarFill1");

            if (hidden)
            {
                Button1.Hidden(false);
                ToolbarFill1.Hidden(false);
            }
            else
            {
                Button1.Hidden(true);
                ToolbarFill1.Hidden(true);
            }

            return UIHelper.Result();
        }


        public IActionResult OnPostBtnHideFill2_Click(bool hidden)
        {
            var ToolbarFill5 = UIHelper.ToolbarFill("ToolbarFill5");
            
            if (hidden)
            {
                ToolbarFill5.Hidden(false);
            }
            else
            {
                ToolbarFill5.Hidden(true);
            }

            return UIHelper.Result();
        }

    }
}