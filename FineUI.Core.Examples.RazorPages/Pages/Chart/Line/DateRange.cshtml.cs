using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace FineUI.Core.Examples.RazorPages.Pages.Chart.Line
{
    public class DateRangeModel : PageBase
    {
        public void OnGet()
        {
            var visits = ChartInteractionData.DailyVisits();
            ViewData["VisitRange"] = ChartInteractionData.FirstDate + " - " + ChartInteractionData.LastDate;
            ViewData["Rows"] = visits;
            ViewData["Scope"] = ChartInteractionData.VisitSummary(visits);
        }

        public IActionResult OnPostQueryVisits(string dpVisitRange)
        {
            // 范围选择器提交一段完整文本，例如 2026-09-03 - 2026-09-05。
            var dates = dpVisitRange?.Split(new[] { " - " }, System.StringSplitOptions.None);
            var visits = dates?.Length == 2 ? ChartInteractionData.DailyVisits(dates[0], dates[1]) : null;
            if (visits == null)
            {
                UIHelper.ToolbarText("ToolbarTextChartScope").Text("请选择有效日期，开始日期须早于或等于结束日期");
                return UIHelper.Result();
            }

            UIHelper.Chart("ChartVisitRange").LoadData(JArray.FromObject(visits));
            UIHelper.ToolbarText("ToolbarTextChartScope").Text(ChartInteractionData.VisitSummary(visits));
            return UIHelper.Result();
        }
    }
}
