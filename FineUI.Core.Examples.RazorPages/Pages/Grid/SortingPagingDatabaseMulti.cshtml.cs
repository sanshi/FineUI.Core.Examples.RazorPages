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
    public class SortingPagingDatabaseMultiModel : BaseModel
    {
        public void OnGet()
        {
            LoadData();


        }


        
        #region BindGrid

        private void LoadData()
        {
            string[] sortFields = new string[] { "Gender", "ASC" };

            var recordCount = DataSourceUtil.GetTotalCount();

            // 1.设置总项数（特别注意：数据库分页初始化时，一定要设置总记录数RecordCount）
            ViewBag.Grid1RecordCount = recordCount;

            // 2.获取当前分页数据
            ViewBag.Grid1DataSource = DataSourceUtil.GetPagedDataTable(pageIndex: 0, 
                pageSize: 5,
                sortFields: sortFields);

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

        #endregion

        public IActionResult OnPostGrid1_PageIndexChangedOrSort(string[] Grid1_fields, int Grid1_pageIndex, string[] Grid1_sortFields)
        {
            var grid1 = UIHelper.Grid("Grid1");

            var recordCount = DataSourceUtil.GetTotalCount();

            // 1.设置总项数（数据库分页回发时，如果总记录数不变，可以不设置RecordCount）
            grid1.RecordCount(recordCount);

            // 2.获取当前分页数据
            var dataSource = DataSourceUtil.GetPagedDataTable(pageIndex: Grid1_pageIndex, pageSize: 5, sortFields: Grid1_sortFields);
            grid1.DataSource(dataSource, Grid1_fields);

            UIHelper.Label("labSortOrderTip").Text(GetSortTip(Grid1_sortFields));


            return UIHelper.Result();
        }

    }
}