using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.GridPaging
{
    public class DatabaseMoreModel : BaseModel
    {
	    private static readonly int PAGESIZE = 5;

        public void OnGet()
        {
            LoadData();


        }

        #region BindGrid

        private void LoadData()
        {
            ViewBag.Grid1DataSource = DataSourceUtil.GetPagedDataTable(pageIndex: 0, pageSize: PAGESIZE);

        }

        #endregion

        public IActionResult OnPostBtnMore_Click(string[] Grid1_fields, int dataIndex)
        {
            var grid1 = UIHelper.Grid("Grid1");
            var btnMore = UIHelper.LinkButton("btnMore");

            dataIndex++;

            var pageCount = DataSourceUtil.GetPageCount(PAGESIZE);
            if (dataIndex <= pageCount - 1)
            {
                var dataSource = DataSourceUtil.GetPagedDataTable(pageIndex: dataIndex, pageSize: PAGESIZE);
                grid1.AppendData(dataSource, Grid1_fields); // 追加数据

                grid1.Attribute("data-index", dataIndex.ToString());
            }

            if (dataIndex == pageCount - 1)
            {
                btnMore.Enabled(false);
                btnMore.Text("全部加载完毕");
            }
            return UIHelper.Result();
        }

    }
}