using Microsoft.AspNetCore.Mvc;

namespace FineUI.Core.Examples.RazorPages.Pages.Chart.Pie
{
    public class ChannelDetailsModel : PageBase
    {
        public void OnGet()
        {
            var rows = ChartInteractionData.ChannelTotals();
            ViewData["Rows"] = rows;
            ViewData["Scope"] = ChartInteractionData.ChannelDetailsSummary(null, null);
        }

        public IActionResult OnPostChartChannelDetails_PointClick(string seriesKey, string dataKey)
        {
            if (seriesKey == "amount" && ChartInteractionData.ChannelName(dataKey) != null)
            {
                var rows = ChartInteractionData.ChannelTrend(dataKey);
                UIHelper.Grid("GridChannelMonths").DataSource(rows, new[] { "Category", "Amount" });
                UIHelper.ToolbarText("ToolbarTextChartScope").Text(ChartInteractionData.ChannelDetailsSummary(dataKey, rows));
            }
            return UIHelper.Result();
        }

        public IActionResult OnPostBtnClear_Click()
        {
            var rows = new ChartInteractionData.ChartRow[0];
            UIHelper.Grid("GridChannelMonths").DataSource(rows, new[] { "Category", "Amount" });
            UIHelper.ToolbarText("ToolbarTextChartScope").Text(ChartInteractionData.ChannelDetailsSummary(null, rows));
            return UIHelper.Result();
        }
    }
}
