namespace FineUI.Core.Examples.RazorPages.Pages.Chart.Pie
{
    public class BasicModel : PageBase
    {
        public object ChartRows { get; private set; }

        public void OnGet()
        {
            ChartRows = new[]
            {
                new { Category = "Search Engine", Value = 1048 },
                new { Category = "Direct", Value = 735 },
                new { Category = "Email", Value = 580 },
                new { Category = "Union Ads", Value = 484 },
                new { Category = "Video Ads", Value = 300 }
            };
        }
    }
}
