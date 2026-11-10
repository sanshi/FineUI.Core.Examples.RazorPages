namespace FineUI.Core.Examples.RazorPages.Pages.Chart.Area
{
    public class StackAllModel : PageBase
    {
        public object ChartRows { get; private set; }

        public void OnGet()
        {
            ChartRows = new[]
            {
                new { Category = "1", Baseline = 3, Change = 1 },
                new { Category = "2", Baseline = 1, Change = 1 },
                new { Category = "3", Baseline = 2, Change = 1 },
                new { Category = "4", Baseline = -1, Change = 1 },
                new { Category = "5", Baseline = -3, Change = 1 },
                new { Category = "6", Baseline = 1, Change = 1 },
                new { Category = "7", Baseline = 3, Change = 1 },
                new { Category = "8", Baseline = -3, Change = -1 },
                new { Category = "9", Baseline = -1, Change = -1 },
                new { Category = "10", Baseline = -2, Change = -1 },
                new { Category = "11", Baseline = 1, Change = -1 },
                new { Category = "12", Baseline = 3, Change = -1 },
                new { Category = "13", Baseline = -1, Change = -1 },
                new { Category = "14", Baseline = -3, Change = -1 }
            };
        }
    }
}
