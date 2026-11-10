using System.Globalization;
using Microsoft.AspNetCore.Mvc;

namespace FineUI.Core.Examples.RazorPages.Pages.Chart.Line
{
    public class PointDetailsModel : PageBase
    {
        public void OnGet()
        {
            ViewData["Rows"] = DailyVisitData.DailyVisits();
        }

        public IActionResult OnPostChartDailyVisits_PointClick(string seriesKey, string dataKey)
        {
            var details = DailyVisitData.FindVisit(dataKey);
            if (seriesKey == "amount" && details != null)
            {
                UIHelper.Label("labVisitDate").Text("日期：" + dataKey);
                UIHelper.Label("labVisitCount").Text("访问量：" + details.Visits);
                UIHelper.Label("labConversionCount").Text("转化量：" + details.Conversions);
                var rate = (details.Conversions * 100.0 / details.Visits).ToString("0.0", CultureInfo.InvariantCulture);
                UIHelper.Label("labConversionRate").Text("转化率：" + rate + "%");
                UIHelper.Window("WindowVisitDetails").Show();
            }
            return UIHelper.Result();
        }
    }
}
