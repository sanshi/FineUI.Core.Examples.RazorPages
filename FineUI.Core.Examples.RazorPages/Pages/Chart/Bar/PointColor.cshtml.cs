namespace FineUI.Core.Examples.RazorPages.Pages.Chart.Bar
{
    public class PointColorModel : PageBase
    {
        public object ChartRows { get; private set; }

        public void OnGet()
        {
            ChartRows = new[]
            {
                new { Category = "Mon", Value = 120, PointColor = "" },
                new { Category = "Tue", Value = 200, PointColor = "#505372" },
                new { Category = "Wed", Value = 150, PointColor = "" },
                new { Category = "Thu", Value = 80, PointColor = "" },
                new { Category = "Fri", Value = 70, PointColor = "" },
                new { Category = "Sat", Value = 110, PointColor = "" },
                new { Category = "Sun", Value = 130, PointColor = "" }
            };
        }
    }
}
