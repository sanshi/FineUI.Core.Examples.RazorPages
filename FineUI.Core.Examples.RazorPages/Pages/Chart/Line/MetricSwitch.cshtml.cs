using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Linq;
using ChartRow = FineUI.Core.Examples.RazorPages.Pages.Chart.ChartDataRows.ChartRow;

namespace FineUI.Core.Examples.RazorPages.Pages.Chart.Line
{
    public class MetricSwitchModel : PageBase
    {
        public void OnGet()
        {
            var rows = DailyMetric("visits");
            ViewData["Rows"] = rows;
            ViewData["Scope"] = MetricSummary("visits", rows);
        }

        public IActionResult OnPostRblMetric_SelectedIndexChanged(string metric)
        {
            var rows = DailyMetric(metric);
            UIHelper.Chart("ChartMetricTrend").LoadData(JArray.FromObject(rows));
            UIHelper.ToolbarText("ToolbarTextChartScope").Text(MetricSummary(metric, rows));
            return UIHelper.Result();
        }

        private static ChartRow[] DailyMetric(string metric)
        {
            var rows = DailyVisitData.DailyVisits();
            return metric == "conversions"
                ? rows.Select(row => new ChartRow(row.Key, row.Category, DailyVisitData.FindVisit(row.Key).Conversions)).ToArray()
                : rows;
        }

        private static string MetricSummary(string metric, ChartRow[] rows)
        {
            var name = metric == "conversions" ? "转化量" : "访问量";
            return $"{name}合计：{rows.Sum(row => row.Amount)}";
        }
    }
}
