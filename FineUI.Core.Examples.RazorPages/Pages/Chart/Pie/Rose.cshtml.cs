namespace FineUI.Core.Examples.RazorPages.Pages.Chart.Pie
{
    public class RoseModel : PageBase
    {
        public object ChartRows { get; private set; }

        public void OnGet()
        {
            ChartRows = new[]
            {
                new { Category = "A", Value = 100 },
                new { Category = "B", Value = 200 },
                new { Category = "C", Value = 300 },
                new { Category = "D", Value = 400 },
                new { Category = "E", Value = 500 }
            };
        }
    }
}
