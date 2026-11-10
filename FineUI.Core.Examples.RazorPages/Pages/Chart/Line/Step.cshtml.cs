namespace FineUI.Core.Examples.RazorPages.Pages.Chart.Line
{
    public class StepModel : PageBase
    {
        public object ChartRows { get; private set; }

        public void OnGet()
        {
            ChartRows = new[]
            {
                new { Category = "Mon", AtStart = 120, AtMiddle = 220, AtEnd = 450 },
                new { Category = "Tue", AtStart = 132, AtMiddle = 282, AtEnd = 432 },
                new { Category = "Wed", AtStart = 101, AtMiddle = 201, AtEnd = 401 },
                new { Category = "Thu", AtStart = 134, AtMiddle = 234, AtEnd = 454 },
                new { Category = "Fri", AtStart = 90, AtMiddle = 290, AtEnd = 590 },
                new { Category = "Sat", AtStart = 230, AtMiddle = 430, AtEnd = 530 },
                new { Category = "Sun", AtStart = 210, AtMiddle = 410, AtEnd = 510 }
            };
        }
    }
}
