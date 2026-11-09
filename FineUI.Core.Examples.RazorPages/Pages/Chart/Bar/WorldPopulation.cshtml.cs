namespace FineUI.Core.Examples.RazorPages.Pages.Chart.Bar
{
    public class WorldPopulationModel : PageBase
    {
        public object ChartRows { get; private set; }

        public void OnGet()
        {
            ChartRows = new[]
            {
                new { Category = "Brazil", Population2011 = 18203, Population2012 = 19325 },
                new { Category = "Indonesia", Population2011 = 23489, Population2012 = 23438 },
                new { Category = "USA", Population2011 = 29034, Population2012 = 31000 },
                new { Category = "India", Population2011 = 104970, Population2012 = 121594 },
                new { Category = "China", Population2011 = 131744, Population2012 = 134141 },
                new { Category = "World", Population2011 = 630230, Population2012 = 681807 }
            };
        }
    }
}
