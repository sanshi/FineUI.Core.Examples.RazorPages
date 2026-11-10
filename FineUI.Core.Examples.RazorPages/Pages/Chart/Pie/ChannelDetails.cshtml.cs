using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ChartRow = FineUI.Core.Examples.RazorPages.Pages.Chart.ChartDataRows.ChartRow;

namespace FineUI.Core.Examples.RazorPages.Pages.Chart.Pie
{
    public class ChannelDetailsModel : PageBase
    {
        public void OnGet()
        {
            var rows = ChannelVisitData.ChannelTotals();
            ViewData["Rows"] = rows;
            ViewData["Scope"] = ChannelDetailsSummary(null, null);
        }

        public IActionResult OnPostChartChannelDetails_PointClick(string seriesKey, string pointId)
        {
            if (seriesKey == "amount" && ChannelVisitData.ChannelName(pointId) != null)
            {
                var rows = ChannelVisitData.ChannelTrend(pointId);
                UIHelper.Grid("GridChannelMonths").DataSource(rows, new[] { "Category", "Amount" });
                UIHelper.ToolbarText("ToolbarTextChartScope").Text(ChannelDetailsSummary(pointId, rows));
            }
            return UIHelper.Result();
        }

        public IActionResult OnPostBtnClear_Click()
        {
            var rows = new ChartRow[0];
            UIHelper.Grid("GridChannelMonths").DataSource(rows, new[] { "Category", "Amount" });
            UIHelper.ToolbarText("ToolbarTextChartScope").Text(ChannelDetailsSummary(null, rows));
            return UIHelper.Result();
        }

        private static string ChannelDetailsSummary(string key, ChartRow[] rows)
        {
            return key == null ? "请选择一个渠道" : $"{ChannelVisitData.ChannelName(key)} · 六个月访问量 {rows.Sum(row => row.Amount)}";
        }
    }
}
