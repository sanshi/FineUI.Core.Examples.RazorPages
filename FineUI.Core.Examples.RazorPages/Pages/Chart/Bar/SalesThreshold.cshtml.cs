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

        public IActionResult OnPostDdlMinimum_SelectedIndexChanged(string ddlMinimum)
        {
            var rows = RegionThreshold(ddlMinimum);
            if (rows != null)
            {
                UIHelper.Chart("ChartSalesThreshold").LoadData(JArray.FromObject(rows));
            }
            UIHelper.ToolbarText("ToolbarTextChartScope").Text(ThresholdSummary(rows));
            return UIHelper.Result();
        }

        // 这页单独使用一组差距较大的金额。比如选择 4,500 元时，西北的 3,500 元柱会被筛掉。
        private static readonly ChartRow[] ThresholdSales =
        {
            new ChartRow("east", "华东", 68000),
            new ChartRow("south", "华南", 49000),
            new ChartRow("north", "华北", 32000),
            new ChartRow("southwest", "西南", 19000),
            new ChartRow("central", "华中", 9500),
            new ChartRow("northwest", "西北", 3500),
        };

        private static ChartRow[] RegionThreshold(string minimum)
        {
            if (!int.TryParse(minimum, NumberStyles.None, CultureInfo.InvariantCulture, out int value))
            {
                return null;
            }

            return ThresholdSales.Where(row => row.Amount >= value).ToArray();
        }

        private static string ThresholdSummary(ChartRow[] rows)
        {
            if (rows == null)
            {
                return "请选择有效的最低销售额";
            }
            return rows.Length == 0 ? "没有达到门槛的区域" : $"符合门槛的区域：{rows.Length} 个";
        }
    }
}
