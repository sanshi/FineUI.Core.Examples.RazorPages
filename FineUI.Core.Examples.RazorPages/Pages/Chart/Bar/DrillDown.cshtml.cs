using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace FineUI.Core.Examples.RazorPages.Pages.Chart.Bar
{
    public class DrillDownModel : PageBase
    {
        public void OnGet()
        {
            ViewData["Rows"] = RegionSalesData.RegionTotals();
            ViewData["Scope"] = "各区域销售额";
        }

        public IActionResult OnPostChartRegionSales_PointClick(string seriesKey, string dataKey)
        {
            var cities = RegionSalesData.CityTotals(dataKey);
            if (seriesKey == "amount" && cities.Length > 0)
            {
                UIHelper.Chart("ChartRegionSales").LoadData(JArray.FromObject(cities));
                UIHelper.ToolbarText("ToolbarTextChartScope").Text(RegionSalesData.RegionName(dataKey) + " · 城市销售额");
                UIHelper.Button("btnBack").Enabled(true);
            }
            return UIHelper.Result();
        }

        public IActionResult OnPostBtnBack_Click()
        {
            UIHelper.Chart("ChartRegionSales").LoadData(JArray.FromObject(RegionSalesData.RegionTotals()));
            UIHelper.ToolbarText("ToolbarTextChartScope").Text("各区域销售额");
            UIHelper.Button("btnBack").Enabled(false);
            return UIHelper.Result();
        }
    }
}
