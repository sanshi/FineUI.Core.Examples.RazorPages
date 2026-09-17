using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Grid
{
    public class SortingClientSorterModel : BaseModel
    {
        public void OnGet()
        {
            ViewBag.Grid1DataSource = DataSourceUtil.GetDataTable();


        }


        
    }
}