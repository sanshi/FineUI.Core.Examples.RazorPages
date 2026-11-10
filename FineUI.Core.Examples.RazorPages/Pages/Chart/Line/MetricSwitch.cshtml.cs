using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace FineUI.Core.Examples.RazorPages.Pages.Chart.Line
{
    public class MetricSwitchModel : PageBase
    {
        public void OnGet()
        {
            var rows = ChartInteractionData.DailyMetric("visits");
            ViewData["Rows"] = rows;
            ViewData["Scope"] = ChartInteractionData.MetricSummary("visits", rows);
        }

        public IActionResult OnPostChangeMetric(string metric)
        {
            var rows = ChartInteractionData.DailyMetric(metric);
            UIHelper.Chart("ChartMetricTrend").LoadData(JArray.FromObject(rows));
            UIHelper.ToolbarText("ToolbarTextChartScope").Text(ChartInteractionData.MetricSummary(metric, rows));
            return UIHelper.Result();
        }
    }
}
