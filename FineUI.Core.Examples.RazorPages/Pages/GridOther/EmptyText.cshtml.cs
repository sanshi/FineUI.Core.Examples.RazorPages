using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.DataProtection.KeyManagement;


namespace FineUI.Core.Examples.RazorPages.Pages.GridOther
{
    public class EmptyTextModel : BaseModel
    {
        public void OnGet()
        {
            ViewBag.Grid1DataSource = DataSourceUtil.GetDataTable();
            ViewBag.Grid1DataSourceKey = "source1";
        }


        
        public IActionResult OnPostButton1_Click(string[] fields, string source)
        {
            var grid1 = UIHelper.Grid("Grid1");

            if (String.IsNullOrEmpty(source) || source == "source2")
            {
                grid1.DataSource(DataSourceUtil.GetDataTable(), fields);
                grid1.Attribute("data-source-key", "source1");
            }
            else
            {
                grid1.DataSource(null);
                grid1.Attribute("data-source-key", "source2");
            }

            return UIHelper.Result();
        }

    }
}