using Microsoft.AspNetCore.Mvc;

namespace FineUI.Core.Examples.RazorPages.Pages.GridCard
{
    public class CardRebindModel : BaseModel
    {
        public void OnGet()
        {

        }


        public IActionResult OnPostButton1_Click(string[] fields, string source)
        {
            var grid1 = UIHelper.Grid("Grid1");

            if (source == "source1")
            {
                grid1.DataSource(DataSourceUtil.GetDataTable(), fields);
                grid1.Attribute("data-source-key", "source2");
            }
            else
            {
                grid1.DataSource(null);
                grid1.Attribute("data-source-key", "source1");
            }

            return UIHelper.Result();
        }


    }
}
