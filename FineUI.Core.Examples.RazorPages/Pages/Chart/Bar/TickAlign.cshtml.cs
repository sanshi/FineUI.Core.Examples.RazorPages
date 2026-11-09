namespace FineUI.Core.Examples.RazorPages.Pages.Chart.Bar
{
    public class TickAlignModel : PageBase
    {
        public object ChartRows { get; private set; }

        public void OnGet()
        {
            ChartRows = new[]
            {
                new { Category = "Mon", Value = 10 },
                new { Category = "Tue", Value = 52 },
                new { Category = "Wed", Value = 200 },
                new { Category = "Thu", Value = 334 },
                new { Category = "Fri", Value = 390 },
                new { Category = "Sat", Value = 330 },
                new { Category = "Sun", Value = 220 }
            };
        }
    }
}
