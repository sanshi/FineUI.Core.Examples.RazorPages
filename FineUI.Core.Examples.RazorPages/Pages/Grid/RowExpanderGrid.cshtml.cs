using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Grid
{
    public class RowExpanderGridModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostBtnSubmit_Click()
        {
			

            return UIHelper.Result();
        }

    }
}