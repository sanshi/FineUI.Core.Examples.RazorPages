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
    public class SortingCancelModel : BaseModel
    {
        public void OnGet()
        {
            LoadData();


        }


        
        private void LoadData()
        {
            string sortField = "Gender";
            string sortDirection = "ASC";

            ViewBag.Grid1DataSource = GetSortedDataTable(sortField, sortDirection);

            ViewBag.Grid1SortField = sortField;
            ViewBag.Grid1SortDirection = sortDirection;
        }

        private DataTable GetSortedDataTable(string sortField, string sortDirection)
        {
            // 模拟数据排序
            DataTable table = DataSourceUtil.GetDataTable();
            DataView view1 = table.DefaultView;
            view1.Sort = String.Format("{0} {1}", sortField, sortDirection);

            return view1.ToTable();
        }

        public IActionResult OnPostGrid1_Sort(string[] Grid1_fields, string Grid1_sortField, string Grid1_sortDirection)
        {
            DataTable table;
            // 判断是否启用排序
            if (!String.IsNullOrEmpty(Grid1_sortField))
            {
                table = GetSortedDataTable(Grid1_sortField, Grid1_sortDirection);
            }
            else
            {
                table = DataSourceUtil.GetDataTable();
            }
            // 更新表格数据源
            UIHelper.Grid("Grid1").DataSource(table, Grid1_fields);

            return UIHelper.Result();
        }

    }
}