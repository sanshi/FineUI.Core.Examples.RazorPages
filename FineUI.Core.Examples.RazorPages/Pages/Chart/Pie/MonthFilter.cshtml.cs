using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace FineUI.Core.Examples.RazorPages.Pages.Chart.Pie
{
    public class MonthFilterModel : PageBase
    {
        public void OnGet()
        {
            var rows = ChartInteractionData.ChannelDistribution("all");
            ViewData["Rows"] = rows;
            ViewData["Scope"] = ChartInteractionData.DistributionSummary("all", rows);
        }

        public IActionResult OnPostDdlMonth_SelectedIndexChanged(string month)
        {
            var rows = ChartInteractionData.ChannelDistribution(month);
            if (rows.Length > 0)
            {
                UIHelper.Chart("ChartChannelMonth").LoadData(JArray.FromObject(rows));
                UIHelper.ToolbarText("ToolbarTextChartScope").Text(ChartInteractionData.DistributionSummary(month, rows));
            }
            return UIHelper.Result();
        }
    }
}
