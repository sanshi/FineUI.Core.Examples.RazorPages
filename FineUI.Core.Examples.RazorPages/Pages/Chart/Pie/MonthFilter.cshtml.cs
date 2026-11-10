using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Linq;
using System;
using ChartRow = FineUI.Core.Examples.RazorPages.Pages.Chart.ChartDataRows.ChartRow;

namespace FineUI.Core.Examples.RazorPages.Pages.Chart.Pie
{
    public class MonthFilterModel : PageBase
    {
        public void OnGet()
        {
            var rows = ChannelVisitData.ChannelTotals();
            ViewData["Rows"] = rows;
            ViewData["Scope"] = DistributionSummary("all", rows);
        }

        public IActionResult OnPostDdlMonth_SelectedIndexChanged(string month)
        {
            var rows = month == "all" ? ChannelVisitData.ChannelTotals() : ChannelVisitData.ChannelTotals(month);
            if (rows.Length > 0)
            {
                UIHelper.Chart("ChartChannelMonth").LoadData(JArray.FromObject(rows));
                UIHelper.ToolbarText("ToolbarTextChartScope").Text(DistributionSummary(month, rows));
            }
            return UIHelper.Result();
        }

        private static string DistributionSummary(string month, ChartRow[] rows)
        {
            var range = month == "all" ? "全部月份" : Array.Find(ChannelVisitData.ChannelTrend(), row => row.Key == month)?.Category;
            return $"{range} · 总访问量 {rows.Sum(row => row.Amount)}";
        }
    }
}
