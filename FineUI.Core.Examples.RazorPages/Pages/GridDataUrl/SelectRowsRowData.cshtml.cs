using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using Newtonsoft.Json.Linq;


namespace FineUI.Core.Examples.RazorPages.Pages.GridDataUrl
{
    public class SelectRowsRowDataModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostButton2_Click()
        {
            UIHelper.Grid("Grid1").SelectedRowIDArray("102", "106", "108");

            return UIHelper.Result();
        }

    }
}