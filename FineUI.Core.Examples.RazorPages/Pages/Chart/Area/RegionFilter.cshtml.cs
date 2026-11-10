using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace FineUI.Core.Examples.RazorPages.Pages.Chart.Area
{
    public class RegionFilterModel : PageBase
    {
        public void OnGet()
        {
            var totals = ChartInteractionData.RegionTrend("east");
            ViewData["Rows"] = totals;
            ViewData["Scope"] = ChartInteractionData.AreaSummary(totals);
        }

        public IActionResult OnPostFilterRegions(string[] selected)
        {
            var totals = ChartInteractionData.RegionTrend(selected);
            UIHelper.Chart("ChartAreaSales").LoadData(JArray.FromObject(totals));
            UIHelper.ToolbarText("ToolbarTextChartScope").Text(ChartInteractionData.AreaSummary(totals));
            return UIHelper.Result();
        }
    }
}
