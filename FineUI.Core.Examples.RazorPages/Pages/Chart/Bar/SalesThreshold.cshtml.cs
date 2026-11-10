using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Globalization;
using ChartRow = FineUI.Core.Examples.RazorPages.Pages.Chart.ChartDataRows.ChartRow;

namespace FineUI.Core.Examples.RazorPages.Pages.Chart.Bar
{
    public class SalesThresholdModel : PageBase
    {
        public void OnGet()
        {
            var rows = RegionThreshold("0");
            ViewData["Rows"] = rows;
            ViewData["Scope"] = ThresholdSummary(rows);
        }

        public IActionResult OnPostBtnFilter_Click(string nbxMinimum)
        {
            var rows = RegionThreshold(nbxMinimum);
            if (rows != null)
            {
                UIHelper.Chart("ChartSalesThreshold").LoadData(JArray.FromObject(rows));
            }
            UIHelper.ToolbarText("ToolbarTextChartScope").Text(ThresholdSummary(rows));
            return UIHelper.Result();
        }

        private static ChartRow[] RegionThreshold(string minimum)
        {
            if (!int.TryParse(minimum, NumberStyles.None, CultureInfo.InvariantCulture, out int value))
            {
                return null;
            }

            return RegionSalesData.RegionTotals().Where(row => row.Amount >= value).OrderByDescending(row => row.Amount).ToArray();
        }

        private static string ThresholdSummary(ChartRow[] rows)
        {
            if (rows == null)
            {
                return "请输入非负整数金额";
            }
            return rows.Length == 0 ? "没有达到门槛的区域" : $"符合门槛的区域：{rows.Length} 个";
        }
    }
}
