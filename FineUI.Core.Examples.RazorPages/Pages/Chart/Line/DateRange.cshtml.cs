using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Linq;
using ChartRow = FineUI.Core.Examples.RazorPages.Pages.Chart.ChartDataRows.ChartRow;

namespace FineUI.Core.Examples.RazorPages.Pages.Chart.Line
{
    public class DateRangeModel : PageBase
    {
        public void OnGet()
        {
            var visits = DailyVisitData.DailyVisits();
            ViewData["VisitRange"] = DailyVisitData.FirstDate + " - " + DailyVisitData.LastDate;
            ViewData["Rows"] = visits;
            ViewData["Scope"] = VisitSummary(visits);
        }

        public IActionResult OnPostDpVisitRange_TextChanged(string dpVisitRange)
        {
            // 范围选择器提交一段完整文本，例如 2026-09-03 - 2026-09-05。
            var dates = dpVisitRange?.Split(new[] { " - " }, System.StringSplitOptions.None);
            var visits = dates?.Length == 2 ? DailyVisitData.DailyVisits(dates[0], dates[1]) : null;
            if (visits == null)
            {
                UIHelper.ToolbarText("ToolbarTextChartScope").Text("请选择有效日期，开始日期须早于或等于结束日期");
                return UIHelper.Result();
            }

            UIHelper.Chart("ChartVisitRange").LoadData(JArray.FromObject(visits));
            UIHelper.ToolbarText("ToolbarTextChartScope").Text(VisitSummary(visits));
            return UIHelper.Result();
        }

        private static string VisitSummary(ChartRow[] rows)
        {
            return rows.Length == 0 ? "所选日期内没有访问数据" : $"{rows.Length} 天 · 访问量 {rows.Sum(row => row.Amount)}";
        }
    }
}
