namespace FineUI.Core.Examples.RazorPages.Pages.GridBigData
{
    public class BigData10000PagingModel : PageBase
    {
        public void OnGet()
        {
            ViewBag.Grid1DataSource = BigDataUtil.GetBigData(10000);
        }




    }
}
