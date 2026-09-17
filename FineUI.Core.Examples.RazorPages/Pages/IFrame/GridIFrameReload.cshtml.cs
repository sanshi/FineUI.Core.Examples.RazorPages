using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.IFrame
{
    public class GridIFrameReloadModel : BaseModel
    {
        public void OnGet()
        {

        }

        
        private void AutoBindGrid(string Grid1_sourceKey, string[] Grid1_fields, string Window1_closeArgument)
        {
            var grid1 = UIHelper.Grid("Grid1");

            DataTable source = null;
            if (Grid1_sourceKey == "table1")
            {
                source = DataSourceUtil.GetDataTable2();
                Grid1_sourceKey = "table2";
            }
            else
            {
                source = DataSourceUtil.GetDataTable();
                Grid1_sourceKey = "table1";
            }

            grid1.DataSource(source, Grid1_fields);
            grid1.Attribute("data-source-key", Grid1_sourceKey);

            grid1.Title("表格 - 回发参数：" + Window1_closeArgument);
        }

        public IActionResult OnPostMyCustomPostBack(string type, string Grid1_sourceKey, string[] Grid1_fields, string Window1_closeArgument)
        {
            // 重新绑定表格数据（模拟）
            AutoBindGrid(Grid1_sourceKey, Grid1_fields, Window1_closeArgument);

            return UIHelper.Result();
        }

       
    }
}