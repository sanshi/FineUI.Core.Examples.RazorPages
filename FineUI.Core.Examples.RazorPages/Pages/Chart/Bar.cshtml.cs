namespace FineUI.Core.Examples.RazorPages.Pages.Chart
{
    public class BarModel : PageBase
    {
        public object ChartRows { get; private set; }

        public void OnGet()
        {
            ChartRows = new[]
            {
                new { Category = "Mon", Value = 120 },
                new { Category = "Tue", Value = 200 },
                new { Category = "Wed", Value = 150 },
                new { Category = "Thu", Value = 80 },
                new { Category = "Fri", Value = 70 },
                new { Category = "Sat", Value = 110 },
                new { Category = "Sun", Value = 130 }
            };
        }
    }
}
