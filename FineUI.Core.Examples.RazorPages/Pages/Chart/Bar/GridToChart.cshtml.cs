using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace FineUI.Core.Examples.RazorPages.Pages.Chart.Bar
{
    public class GridToChartModel : PageBase
    {
        public void OnGet()
        {
            ViewData["Regions"] = RegionSalesData.RegionTotals();
            ViewData["Rows"] = RegionSalesData.RegionTrend("east");
            ViewData["Scope"] = "华东 · 月度销售额";
        }

        public IActionResult OnPostGridRegions_RowClick(string rowId)
        {
            var region = RegionSalesData.RegionName(rowId);
            if (region != null)
            {
                UIHelper.Chart("ChartRegionMonths").LoadData(JArray.FromObject(RegionSalesData.RegionTrend(rowId)));
                UIHelper.ToolbarText("ToolbarTextChartScope").Text(region + " · 月度销售额");
            }
            return UIHelper.Result();
        }
    }
}
