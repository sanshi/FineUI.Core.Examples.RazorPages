using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace FineUI.Core.Examples.RazorPages.Pages.Chart.Bar
{
    public class SalesThresholdModel : PageBase
    {
        public void OnGet()
        {
            var rows = ChartInteractionData.RegionThreshold("0");
            ViewData["Rows"] = rows;
            ViewData["Scope"] = ChartInteractionData.ThresholdSummary(rows);
        }

        public IActionResult OnPostBtnFilter_Click(string nbxMinimum)
        {
            var rows = ChartInteractionData.RegionThreshold(nbxMinimum);
            if (rows != null)
            {
                UIHelper.Chart("ChartSalesThreshold").LoadData(JArray.FromObject(rows));
            }
            UIHelper.ToolbarText("ToolbarTextChartScope").Text(ChartInteractionData.ThresholdSummary(rows));
            return UIHelper.Result();
        }
    }
}
