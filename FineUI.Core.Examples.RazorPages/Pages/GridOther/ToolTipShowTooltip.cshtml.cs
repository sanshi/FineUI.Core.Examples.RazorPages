using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.GridOther
{
    public class ToolTipShowToolTipModel : BaseModel
    {
        public void OnGet()
        {
            // 修改最后一行的数据
            DataTable table = DataSourceUtil.GetDataTable();
            DataRow lastRow = table.Rows[table.Rows.Count - 1];
            lastRow["Major"] = "<b>" + lastRow["Major"] + "&</b>";
            ViewBag.Grid1DataSource = table;

        }


        


    }
}