namespace FineUI.Core.Examples.RazorPages.Pages.Chart.Line
{
    public class BasicModel : PageBase
    {
        public object ChartRows { get; private set; }

        public void OnGet()
        {
            ChartRows = new[]
            {
                new { Category = "Mon", Value = 150 },
                new { Category = "Tue", Value = 230 },
                new { Category = "Wed", Value = 224 },
                new { Category = "Thu", Value = 218 },
                new { Category = "Fri", Value = 135 },
                new { Category = "Sat", Value = 147 },
                new { Category = "Sun", Value = 260 }
            };
        }
    }
}
