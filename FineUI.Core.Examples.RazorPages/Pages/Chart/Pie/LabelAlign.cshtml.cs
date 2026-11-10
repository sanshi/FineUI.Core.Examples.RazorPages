namespace FineUI.Core.Examples.RazorPages.Pages.Chart.Pie
{
    public class LabelAlignModel : PageBase
    {
        public object ChartRows { get; private set; }

        public void OnGet()
        {
            ChartRows = new[]
            {
                new { Category = "Apples", Value = 70 },
                new { Category = "Strawberries", Value = 68 },
                new { Category = "Bananas", Value = 48 },
                new { Category = "Oranges", Value = 40 },
                new { Category = "Pears", Value = 32 },
                new { Category = "Pineapples", Value = 27 },
                new { Category = "Grapes", Value = 18 }
            };
        }
    }
}
