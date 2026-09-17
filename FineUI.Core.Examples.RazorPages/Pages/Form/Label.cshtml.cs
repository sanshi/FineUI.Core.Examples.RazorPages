using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Form
{
    public class LabelModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostBtnChangeEnable_Click(bool enabled)
        {
            UIHelper.Label("Label3").Enabled(!enabled);

            return UIHelper.Result();
        }

    }
}