using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Linq;
using ChartRow = FineUI.Core.Examples.RazorPages.Pages.Chart.ChartDataRows.ChartRow;

namespace FineUI.Core.Examples.RazorPages.Pages.Chart.Area
{
    public class RegionFilterModel : PageBase
    {
        public void OnGet()
        {
            var totals = RegionSalesData.RegionTrend("east");
            ViewData["Rows"] = totals;
            ViewData["Scope"] = AreaSummary(totals);
        }

        public IActionResult OnPostCblRegions_SelectedIndexChanged(string[] selected)
        {
            var totals = RegionSalesData.RegionTrend(selected);
            UIHelper.Chart("ChartAreaSales").LoadData(JArray.FromObject(totals));
            UIHelper.ToolbarText("ToolbarTextChartScope").Text(AreaSummary(totals));
            return UIHelper.Result();
        }

        private static string AreaSummary(ChartRow[] rows)
        {
            return rows.Length == 0 ? "请选择至少一个区域" : $"所选区域销售额合计 {rows.Sum(row => row.Amount)} 元";
        }
    }
}
