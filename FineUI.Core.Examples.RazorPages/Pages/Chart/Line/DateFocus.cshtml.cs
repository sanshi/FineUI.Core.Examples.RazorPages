using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace FineUI.Core.Examples.RazorPages.Pages.Chart.Line
{
    public class DateFocusModel : PageBase
    {
        public void OnGet()
        {
            var rows = ChartInteractionData.DailyFocus(ChartInteractionData.FirstDate);
            ViewData["Rows"] = rows;
            ViewData["Scope"] = ChartInteractionData.VisitFocusSummary(ChartInteractionData.FirstDate);
        }

        public IActionResult OnPostChartDateFocus_PointClick(string seriesKey, string dataKey)
        {
            if (seriesKey == "amount" && ChartInteractionData.FindVisit(dataKey) != null)
            {
                UIHelper.DatePicker("dpFocus").Text(dataKey);
                var rows = ChartInteractionData.DailyFocus(dataKey);
                UIHelper.Chart("ChartDateFocus").LoadData(JArray.FromObject(rows));
                UIHelper.ToolbarText("ToolbarTextChartScope").Text(ChartInteractionData.VisitFocusSummary(dataKey));
            }
            return UIHelper.Result();
        }

        public IActionResult OnPostBtnFocus_Click(string dpFocus)
        {
            var rows = ChartInteractionData.DailyFocus(dpFocus);
            UIHelper.Chart("ChartDateFocus").LoadData(JArray.FromObject(rows));
            UIHelper.ToolbarText("ToolbarTextChartScope").Text(ChartInteractionData.VisitFocusSummary(dpFocus));
            return UIHelper.Result();
        }
    }
}
