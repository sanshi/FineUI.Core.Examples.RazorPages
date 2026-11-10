using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace FineUI.Core.Examples.RazorPages.Pages.Chart.Pie
{
    public class TrendLinkModel : PageBase
    {
        public void OnGet()
        {
            ViewData["Rows"] = ChannelVisitData.ChannelTotals();
            ViewData["Trend"] = ChannelVisitData.ChannelTrend();
            ViewData["Scope"] = "全部渠道 · 月度访问趋势";
        }

        public IActionResult OnPostChartChannels_PointClick(string seriesKey, string dataKey)
        {
            var channel = ChannelVisitData.ChannelName(dataKey);
            if (seriesKey == "amount" && channel != null)
            {
                UIHelper.Chart("ChartChannelTrend").LoadData(JArray.FromObject(ChannelVisitData.ChannelTrend(dataKey)));
                UIHelper.ToolbarText("ToolbarTextChartScope").Text(channel + " · 月度访问趋势");
            }
            return UIHelper.Result();
        }

        public IActionResult OnPostBtnAllChannels_Click()
        {
            UIHelper.Chart("ChartChannelTrend").LoadData(JArray.FromObject(ChannelVisitData.ChannelTrend()));
            UIHelper.ToolbarText("ToolbarTextChartScope").Text("全部渠道 · 月度访问趋势");
            return UIHelper.Result();
        }
    }
}
