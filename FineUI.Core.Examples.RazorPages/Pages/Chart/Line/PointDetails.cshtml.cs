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

        public IActionResult OnPostChartDailyVisits_PointClick(string seriesKey, string pointId)
        {
            var details = DailyVisitData.FindVisit(pointId);
            if (seriesKey == "amount" && details != null)
            {
                UIHelper.Label("labVisitDate").Text(pointId);
                UIHelper.Label("labVisitCount").Text(details.Visits.ToString(CultureInfo.InvariantCulture));
                UIHelper.Label("labConversionCount").Text(details.Conversions.ToString(CultureInfo.InvariantCulture));
                var rate = (details.Conversions * 100.0 / details.Visits).ToString("0.0", CultureInfo.InvariantCulture);
                UIHelper.Label("labConversionRate").Text(rate + "%");
            }
            return UIHelper.Result();
        }
    }
}
