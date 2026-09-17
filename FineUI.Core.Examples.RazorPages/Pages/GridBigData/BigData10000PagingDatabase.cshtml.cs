using Microsoft.AspNetCore.Mvc;


namespace FineUI.Core.Examples.RazorPages.Pages.GridBigData
{
    public class BigData10000PagingDatabaseModel : BaseModel
    {
        public void OnGet()
        {
            LoadData();
        }

        #region BindGrid

        private void LoadData()
        {
            // 1.设置总项数（特别注意：数据库分页初始化时，一定要设置总记录数RecordCount）
            ViewBag.Grid1RecordCount = 10000;

            // 2.获取当前分页数据
            ViewBag.Grid1DataSource = BigDataUtil.GetBigData(10000, 0, 120);

        }

        #endregion

        public IActionResult OnPostGrid1_PageIndexChanged(string[] Grid1_fields, int Grid1_pageIndex)
        {
            var grid1 = UIHelper.Grid("Grid1");

            // 1.设置总项数（数据库分页回发时，如果总记录数不变，可以不设置RecordCount）
            grid1.RecordCount(10000);

            // 2.获取当前分页数据
            var dataSource = BigDataUtil.GetBigData(10000, Grid1_pageIndex, 120);
            grid1.DataSource(dataSource, Grid1_fields);

            return UIHelper.Result();
        }




    }
}
