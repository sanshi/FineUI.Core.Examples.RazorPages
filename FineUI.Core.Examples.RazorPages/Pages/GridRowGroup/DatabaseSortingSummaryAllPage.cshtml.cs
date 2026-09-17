using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.GridRowGroup
{
    public class DatabaseSortingSummaryAllPageModel : BaseModel
    {
        public void OnGet()
        {
            LoadData();


        }


        
        #region BindGrid

        private void LoadData()
        {
            string sortField = "Name";
            string sortDirection = "ASC";

            var recordCount = DataSourceUtil.GetTotalCount();

            // 1.设置总项数（特别注意：数据库分页初始化时，一定要设置总记录数RecordCount）
            ViewBag.Grid1RecordCount = recordCount;

            // 2.获取当前分页数据
            var pagedDataTable = DataSourceUtil.GetPagedDataTable(pageIndex: 0,
                pageSize: 10,
                sortField: sortField,
                sortDirection: sortDirection);
            ViewBag.Grid1DataSource = pagedDataTable;

            ViewBag.Grid1SortField = sortField;
            ViewBag.Grid1SortDirection = sortDirection;


            // 3. 合计行数据
            ViewBag.Grid1SummaryDataArray = GetSummaryDataArray(pagedDataTable);
        }



        private JArray GetSummaryDataArray(DataTable source)
        {
            JArray summaryArray = new JArray();

            // 分页合计
            summaryArray.Add(CalcSummaryRow(source, "平均（当前页）："));

            // 全部合计
            summaryArray.Add(CalcSummaryRow(DataSourceUtil.GetDataTable2(), "平均（全部页）："));

            return summaryArray;
        }

        private JObject CalcSummaryRow(DataTable source, string title)
        {
            int chineseScoreTotal = 0;
            int mathScoreTotal = 0;
            int rowCount = source.Rows.Count;
            foreach (DataRow row in source.Rows)
            {
                chineseScoreTotal += Convert.ToInt32(row["ChineseScore"]);
                mathScoreTotal += Convert.ToInt32(row["MathScore"]);
            }


            JObject summary = new JObject();
            summary.Add("Major", title);
            summary.Add("ChineseScore", (chineseScoreTotal / rowCount).ToString("F2"));
            summary.Add("MathScore", (mathScoreTotal / rowCount).ToString("F2"));

            return summary;
        }


        #endregion

        public IActionResult OnPostGrid1_PageIndexChangedOrSort(string[] Grid1_fields, int Grid1_pageIndex, string Grid1_sortField, string Grid1_sortDirection)
        {
            var grid1 = UIHelper.Grid("Grid1");

            var recordCount = DataSourceUtil.GetTotalCount();

            // 1.设置总项数（数据库分页回发时，如果总记录数不变，可以不设置RecordCount）
            grid1.RecordCount(recordCount);

            // 2.获取当前分页数据
            var dataSource = DataSourceUtil.GetPagedDataTable(pageIndex: Grid1_pageIndex, pageSize: 10,  sortField: Grid1_sortField, sortDirection: Grid1_sortDirection);
            grid1.DataSource(dataSource, Grid1_fields);

            // 3. 更新合计行数据
            grid1.SummaryDataArray(GetSummaryDataArray(dataSource));

            return UIHelper.Result();
        }

    }
}