namespace FineUI.Core.Examples.RazorPages.Pages.Chart.Line
{
    public class DashedModel : PageBase
    {
        public object ChartRows { get; private set; }

        public void OnGet()
        {
            ChartRows = new[]
            {
                new { Category = "A", Value = 10 },
                new { Category = "B", Value = 22 },
                new { Category = "C", Value = 28 },
                new { Category = "D", Value = 23 },
                new { Category = "E", Value = 19 }
            };
        }
    }
}
