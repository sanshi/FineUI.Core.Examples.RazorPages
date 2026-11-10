using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace FineUI.Core.Examples.RazorPages.Pages.Chart.Pie
{
    public class TrendLinkModel : PageBase
    {
        public void OnGet()
        {
            ViewData["Rows"] = ChartInteractionData.ChannelTotals();
            ViewData["Trend"] = ChartInteractionData.ChannelTrend();
            ViewData["Scope"] = "全部渠道 · 月度访问趋势";
        }

        public IActionResult OnPostSelectChannel(string seriesKey, string dataKey)
        {
            var channel = ChartInteractionData.ChannelName(dataKey);
            if (seriesKey == "amount" && channel != null)
            {
                UIHelper.Chart("ChartChannelTrend").LoadData(JArray.FromObject(ChartInteractionData.ChannelTrend(dataKey)));
                UIHelper.ToolbarText("ToolbarTextChartScope").Text(channel + " · 月度访问趋势");
            }
            return UIHelper.Result();
        }

        public IActionResult OnPostResetChannels()
        {
            UIHelper.Chart("ChartChannelTrend").LoadData(JArray.FromObject(ChartInteractionData.ChannelTrend()));
            UIHelper.ToolbarText("ToolbarTextChartScope").Text("全部渠道 · 月度访问趋势");
            return UIHelper.Result();
        }
    }
}
