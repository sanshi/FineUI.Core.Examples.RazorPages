using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace FineUI.Core.Examples.RazorPages.Pages.Chart.Area
{
    public class CumulativeModel : PageBase
    {
        public void OnGet()
        {
            var rows = ChartInteractionData.AreaAmounts(false);
            ViewData["Rows"] = rows;
            ViewData["Scope"] = ChartInteractionData.AreaModeSummary(false);
        }

        public IActionResult OnPostCbxCumulative_CheckedChanged(bool cumulative)
        {
            var rows = ChartInteractionData.AreaAmounts(cumulative);
            UIHelper.Chart("ChartCumulativeSales").LoadData(JArray.FromObject(rows));
            UIHelper.ToolbarText("ToolbarTextChartScope").Text(ChartInteractionData.AreaModeSummary(cumulative));
            return UIHelper.Result();
        }
    }
}
