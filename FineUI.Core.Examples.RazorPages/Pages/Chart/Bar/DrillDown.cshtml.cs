using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace FineUI.Core.Examples.RazorPages.Pages.Chart.Bar
{
    public class DrillDownModel : PageBase
    {
        public void OnGet()
        {
            ViewData["Rows"] = ChartInteractionData.RegionTotals();
            ViewData["Scope"] = "各区域销售额";
        }

        public IActionResult OnPostChartRegionSales_PointClick(string seriesKey, string dataKey)
        {
            var cities = ChartInteractionData.CityTotals(dataKey);
            if (seriesKey == "amount" && cities.Length > 0)
            {
                UIHelper.Chart("ChartRegionSales").LoadData(JArray.FromObject(cities));
                UIHelper.ToolbarText("ToolbarTextChartScope").Text(ChartInteractionData.RegionName(dataKey) + " · 城市销售额");
                UIHelper.Button("btnBack").Enabled(true);
            }
            return UIHelper.Result();
        }

        public IActionResult OnPostBtnBack_Click()
        {
            UIHelper.Chart("ChartRegionSales").LoadData(JArray.FromObject(ChartInteractionData.RegionTotals()));
            UIHelper.ToolbarText("ToolbarTextChartScope").Text("各区域销售额");
            UIHelper.Button("btnBack").Enabled(false);
            return UIHelper.Result();
        }
    }
}
