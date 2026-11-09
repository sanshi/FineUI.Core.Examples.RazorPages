namespace FineUI.Core.Examples.RazorPages.Pages.Chart
{
    public class AreaModel : PageBase
    {
        public object ChartRows { get; private set; }

        public void OnGet()
        {
            ChartRows = new[]
            {
                new { Category = "Mon", Value = 820 },
                new { Category = "Tue", Value = 932 },
                new { Category = "Wed", Value = 901 },
                new { Category = "Thu", Value = 934 },
                new { Category = "Fri", Value = 1290 },
                new { Category = "Sat", Value = 1330 },
                new { Category = "Sun", Value = 1320 }
            };
        }
    }
}
