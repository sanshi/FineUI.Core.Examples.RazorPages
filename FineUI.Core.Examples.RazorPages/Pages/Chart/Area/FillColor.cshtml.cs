namespace FineUI.Core.Examples.RazorPages.Pages.Chart.Area
{
    public class FillColorModel : PageBase
    {
        public object ChartRows { get; private set; }

        public void OnGet()
        {
            ChartRows = new[]
            {
                new { Category = "A", First = 10, Second = 25 },
                new { Category = "B", First = 22, Second = 14 },
                new { Category = "C", First = 28, Second = 23 },
                new { Category = "D", First = 23, Second = 35 },
                new { Category = "E", First = 19, Second = 10 }
            };
        }
    }
}
