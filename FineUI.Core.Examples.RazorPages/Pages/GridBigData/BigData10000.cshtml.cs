namespace FineUI.Core.Examples.RazorPages.Pages.GridBigData
{
    public class BigData10000Model : BaseModel
    {
        public void OnGet()
        {
            ViewBag.Grid1DataSource = BigDataUtil.GetBigData(10000);
        }




    }
}
