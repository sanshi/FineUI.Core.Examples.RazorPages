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
    public class SortingNoSortFieldModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostGrid1_Sort(string[] Grid1_fields, string Grid1_sortField, string Grid1_sortDirection)
        {
            // 模拟数据排序
            DataTable table = DataSourceUtil.GetDataTable();
            DataView view1 = table.DefaultView;
            view1.Sort = String.Format("{0} {1}", Grid1_sortField, Grid1_sortDirection);

            // 更新表格数据源
            UIHelper.Grid("Grid1").DataSource(view1, Grid1_fields);

            return UIHelper.Result();
        }


    }
}