namespace FineUI.Core.Examples.RazorPages.Pages.Chart.Bar
{
    public class SpacingModel : PageBase
    {
        public object ChartRows { get; private set; }

        public void OnGet()
        {
            ChartRows = new[]
            {
                new { Category = "A", First = 23, Second = 12 },
                new { Category = "B", First = 24, Second = 14 },
                new { Category = "C", First = 18, Second = 9 },
                new { Category = "D", First = 25, Second = 9 },
                new { Category = "E", First = 18, Second = 11 }
            };
        }
    }
}
