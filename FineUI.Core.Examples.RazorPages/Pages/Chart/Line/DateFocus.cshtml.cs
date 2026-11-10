using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace FineUI.Core.Examples.RazorPages.Pages.Chart.Line
{
    public class DateFocusModel : PageBase
    {
        public void OnGet()
        {
            var rows = DailyFocus(DailyVisitData.FirstDate);
            ViewData["Rows"] = rows;
            ViewData["Scope"] = VisitFocusSummary(DailyVisitData.FirstDate);
        }

        public IActionResult OnPostChartDateFocus_PointClick(string seriesKey, string pointId)
        {
            if (seriesKey == "amount" && DailyVisitData.FindVisit(pointId) != null)
            {
                UIHelper.DatePicker("dpFocus").Text(pointId);
                var rows = DailyFocus(pointId);
                UIHelper.Chart("ChartDateFocus").LoadData(JArray.FromObject(rows));
                UIHelper.ToolbarText("ToolbarTextChartScope").Text(VisitFocusSummary(pointId));
            }
            return UIHelper.Result();
        }

        public IActionResult OnPostBtnFocus_Click(string dpFocus)
        {
            var rows = DailyFocus(dpFocus);
            UIHelper.Chart("ChartDateFocus").LoadData(JArray.FromObject(rows));
            UIHelper.ToolbarText("ToolbarTextChartScope").Text(VisitFocusSummary(dpFocus));
            return UIHelper.Result();
        }

        private static object DailyFocus(string key)
        {
            return DailyVisitData.DailyVisits().Select(row => new
            {
                row.Id,
                row.Category,
                row.Amount,
                Color = row.Id == key ? "#d9480f" : ""
            }).ToArray();
        }

        private static string VisitFocusSummary(string key)
        {
            var details = DailyVisitData.FindVisit(key);
            return details == null ? "所选日期没有访问数据" : $"{key} · 访问量 {details.Visits} · 转化量 {details.Conversions}";
        }
    }
}
