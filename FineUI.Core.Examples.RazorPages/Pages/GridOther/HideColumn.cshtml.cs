using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using Newtonsoft.Json.Linq;


namespace FineUI.Core.Examples.RazorPages.Pages.GridOther
{
    public class HideColumnModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostButton3_Click(bool genderHidden)
        {
            var grid1 = UIHelper.Grid("Grid1");
            if (genderHidden)
            {
                grid1.ShowColumn("Gender");
            }
            else
            {
                grid1.HideColumn("Gender");
            }

            return UIHelper.Result();
        }

    }
}