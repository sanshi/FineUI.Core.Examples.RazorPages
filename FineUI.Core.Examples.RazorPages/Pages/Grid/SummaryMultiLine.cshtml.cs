using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Data;

namespace FineUI.Core.Examples.RazorPages.Pages.Grid
{
    public class SummaryMultiLineModel : BaseModel
    {
        public void OnGet()
        {
            LoadData();


        }



        #region BindGrid

        private void LoadData()
        {
            var recordCount = DataSourceUtil.GetTotalCount();

            // 1.设置总项数（特别注意：数据库分页初始化时，一定要设置总记录数RecordCount）
            ViewBag.Grid1RecordCount = recordCount;

            // 2.获取当前分页数据
            var pagedDataTable = DataSourceUtil.GetPagedDataTable(pageIndex: 0, pageSize: 15);
            ViewBag.Grid1DataSource = pagedDataTable;

            // 3. 合计行数据
            ViewBag.Grid1SummaryDataArray = GetSummaryDataArray(pagedDataTable);
        }

        private JArray GetSummaryDataArray(DataTable source)
        {
            JArray summaryArray = new JArray();

            // 分页合计
            summaryArray.Add(CalcSummaryRow(source, "当前页合计："));

            // 全部合计
            summaryArray.Add(CalcSummaryRow(DataSourceUtil.GetDataTable2(), "全部合计："));

            return summaryArray;
        }

        private JObject CalcSummaryRow(DataTable source, string title)
        {
            float extraFeeTotal = 0.0f;
            float feeTotal = 0.0f;
            foreach (DataRow row in source.Rows)
            {
                extraFeeTotal += Convert.ToInt32(row["ExtraFee"]);
                feeTotal += Convert.ToInt32(row["Fee"]);
            }


            JObject summary = new JObject();
            summary.Add("Major", title);
            summary.Add("Fee", feeTotal.ToString("F2"));
            summary.Add("ExtraFee", extraFeeTotal.ToString("F2"));

            return summary;
        }

        #endregion

        public IActionResult OnPostGrid1_PageIndexChanged(string[] Grid1_fields, int Grid1_pageIndex)
        {
            var grid1 = UIHelper.Grid("Grid1");

            var recordCount = DataSourceUtil.GetTotalCount();

            // 1.设置总项数（数据库分页回发时，如果总记录数不变，可以不设置RecordCount）
            grid1.RecordCount(recordCount);

            // 2.获取当前分页数据
            var dataSource = DataSourceUtil.GetPagedDataTable(pageIndex: Grid1_pageIndex, pageSize: 15);
            grid1.DataSource(dataSource, Grid1_fields);

            // 3. 更新合计行数据
            //grid1.SummaryDataArray(GetSummaryDataArray(dataSource));

            // 3. 更新合计行数据（v7.1.0 - 或者只更新当前页合计）
            grid1.SummaryData(0, CalcSummaryRow(dataSource, "当前页合计："));

            return UIHelper.Result();
        }

    }
}
