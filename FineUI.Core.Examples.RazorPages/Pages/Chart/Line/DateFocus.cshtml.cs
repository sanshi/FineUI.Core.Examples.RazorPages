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

        public IActionResult OnPostChartDateFocus_PointClick(string pointId)
        {
            if (DailyVisitData.FindVisit(pointId) != null)
            {
                UIHelper.DatePicker("dpFocus").Text(pointId);
                UpdateDateFocus(pointId);
            }
            return UIHelper.Result();
        }

        public IActionResult OnPostDpFocus_TextChanged(string dpFocus)
        {
            UpdateDateFocus(dpFocus);
            return UIHelper.Result();
        }

        private void UpdateDateFocus(string date)
        {
            var rows = DailyFocus(date);
            UIHelper.Chart("ChartDateFocus").LoadData(JArray.FromObject(rows));
            UIHelper.ToolbarText("ToolbarTextChartScope").Text(VisitFocusSummary(date));
        }

        private static object DailyFocus(string key)
        {
            return DailyVisitData.DailyVisits().Select(row => new
            {
                row.Id,
                row.Category,
                row.Amount,
                // 只在选中的日期显示标记和数值，其余日期的访问趋势由主折线保留。
                FocusAmount = row.Id == key ? (int?)row.Amount : null,
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
