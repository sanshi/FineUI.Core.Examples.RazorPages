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
    public class SortingMultiModel : BaseModel
    {
        public void OnGet()
        {
            LoadData();


        }


        
        private void LoadData()
        {
            string[] sortFields = new string[] { "EntranceYear", "DESC", "Gender", "ASC" };

            ViewBag.Grid1DataSource = GetSortedDataTable(sortFields);

            ViewBag.Grid1SortFields = sortFields;

            ViewBag.SortTip = GetSortTip(sortFields);
        }


        private string GetSortFieldTip(string sortField, string sortDirection)
        {
            return String.Format("{0}（{1}）", sortField, sortDirection == "ASC" ? "升序" : "降序");
        }

        private string GetSortTip(string[] sortFields)
        {
            List<string> sortTips = new List<string>();

            // 多列排序
            if (sortFields != null && sortFields.Length > 0)
            {
                for (var i = 0; i < sortFields.Length; i += 2)
                {
                    var sortField = sortFields[i];
                    var sortDirection = sortFields[i + 1];

                    sortTips.Add(GetSortFieldTip(sortField, sortDirection));
                }
            }

            return String.Format("排序字段：{0}", String.Join("，", sortTips));
        }

        private DataTable GetSortedDataTable(string[] sortFields)
        {
            DataTable table = DataSourceUtil.GetDataTable();

            // 多列排序
            if (sortFields != null && sortFields.Length > 0)
            {
                List<string> sortItems = new List<string>();
                for (var i = 0; i < sortFields.Length; i += 2)
                {
                    sortItems.Add(String.Format("{0} {1}", sortFields[i], sortFields[i + 1]));
                }

                DataView view1 = table.DefaultView;
                view1.Sort = String.Join(", ", sortItems);

                return view1.ToTable();
            }
            else
            {
                return table;
            }
        }

        public IActionResult OnPostGrid1_Sort(string[] Grid1_fields, string[] Grid1_sortFields)
        {
            // 更新表格数据源
            UIHelper.Grid("Grid1").DataSource(GetSortedDataTable(Grid1_sortFields), Grid1_fields);


            UIHelper.Label("labSortOrderTip").Text(GetSortTip(Grid1_sortFields));


            return UIHelper.Result();
        }

    }
}