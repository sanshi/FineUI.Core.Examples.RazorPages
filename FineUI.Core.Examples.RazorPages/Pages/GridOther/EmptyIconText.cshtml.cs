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
    public class EmptyIconTextModel : BaseModel
    {
        public void OnGet()
        {
            // 初始保持空表格，以便直接看到内置的「图标 + 文案」空状态
            ViewBag.Grid1DataSource = null;
            ViewBag.Grid1DataSourceKey = "source1";
        }



        public IActionResult OnPostButton1_Click(string[] fields, string source)
        {
            var grid1 = UIHelper.Grid("Grid1");

            if (source == "source1")
            {
                grid1.DataSource(DataSourceUtil.GetDataTable(), fields);
                grid1.Attribute("data-source-key", "source2");
            }
            else
            {
                grid1.DataSource(null);
                grid1.Attribute("data-source-key", "source1");
            }

            return UIHelper.Result();
        }

    }
}
