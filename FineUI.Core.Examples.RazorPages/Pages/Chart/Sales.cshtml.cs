using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace FineUI.Core.Examples.RazorPages.Pages.Chart
{
    public class SalesModel : PageBase
    {
        public void OnGet() { }

        public IActionResult OnPostChartSales_PointClick(string seriesKey, string dataKey)
        {
            if (seriesKey == "sales" && ChartSamples.HasMonth(dataKey))
            {
                BindOrders(dataKey);
            }
            return UIHelper.Result();
        }

        public IActionResult OnPostBtnRecent_Click()
        {
            UIHelper.Chart("ChartSales").LoadData(JArray.FromObject(ChartSamples.Months(true)));
            BindOrders(recent: true);
            return UIHelper.Result();
        }

        public IActionResult OnPostBtnReset_Click()
        {
            UIHelper.Chart("ChartSales").LoadData(JArray.FromObject(ChartSamples.Months()));
            BindOrders();
            return UIHelper.Result();
        }

        private static void BindOrders(string month = null, bool recent = false)
        {
            var orders = ChartSamples.Details(month, recent);
            UIHelper.Grid("GridOrders").DataSource(orders, new[] { "Number", "Customer", "Month", "Amount" });
            UIHelper.ToolbarText("ToolbarTextOrderScope").Text(ChartSamples.OrderScope(month, recent, orders.Length));
        }
    }
}
