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
    public class PagingTypeModel : BaseModel
    {
        public void OnGet()
        {
            var pagingType = Request.Query["type"];
            if (String.IsNullOrEmpty(pagingType))
            {
                // 缺省选中值
                pagingType = "ArrowNumberBox";
            }
            ViewBag.Grid1PagingType = (PagingType)Enum.Parse(typeof(PagingType), pagingType, true);
            ViewBag.PagingType = pagingType;

            if (pagingType == "NumberButton" || pagingType == "ArrowNumberButton")
            {
                ViewBag.ddlMaxPagingNumberButtonEnabled = true;
            }
            else
            {
                ViewBag.ddlMaxPagingNumberButtonEnabled = false;
            }


            var isShowMessage = true;
            var showMessage = Request.Query["message"];
            if (!String.IsNullOrEmpty(showMessage))
            {
                isShowMessage = Convert.ToBoolean(showMessage);
            }
            ViewBag.ShowPagingMessage = isShowMessage;



            var maxNumberButtonCount = 5;
            var maxNumberButton = Request.Query["maxnumberbutton"];
            if (!String.IsNullOrEmpty(maxNumberButton))
            {
                maxNumberButtonCount = Convert.ToInt32(maxNumberButton);
            }
            ViewBag.MaxPagingNumberButton = maxNumberButtonCount;


            LoadData();


        }


        
        #region BindGrid

        private void LoadData()
        {
            // 1.设置总项数（特别注意：数据库分页初始化时，一定要设置总记录数RecordCount）
            ViewBag.Grid1RecordCount = GetTotalCount();

            // 2.获取当前分页数据
            ViewBag.Grid1DataSource = GetPagedDataTable(pageIndex: 0, pageSize: 10);

        }

        /// <summary>
        /// 模拟返回总项数
        /// </summary>
        /// <returns></returns>
        private int GetTotalCount()
        {
            return 999;
        }

        /// <summary>
        /// 模拟数据库分页（实际项目中请直接使用SQL语句返回分页数据！）
        /// </summary>
        /// <returns></returns>
        private DataTable GetPagedDataTable(int pageIndex, int pageSize)
        {
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("Id", typeof(int)));
            table.Columns.Add(new DataColumn("EntranceTime", typeof(DateTime)));

            DataRow row = null;

            for (int i = pageIndex * pageSize, count = Math.Min(GetTotalCount(), pageIndex * pageSize + pageSize); i < count; i++)
            {
                row = table.NewRow();
                row[0] = 1000 + i;
                row[1] = DateTime.Now.AddSeconds(i);
                table.Rows.Add(row);
            }

            return table;
        }

        #endregion

        public IActionResult OnPostGrid1_PageIndexChanged(string[] Grid1_fields, int Grid1_pageIndex)
        {
            var grid1 = UIHelper.Grid("Grid1");

            // 1.设置总项数（数据库分页回发时，如果总记录数不变，可以不设置RecordCount）
            grid1.RecordCount(GetTotalCount());

            // 2.获取当前分页数据
            var dataSource = GetPagedDataTable(pageIndex: Grid1_pageIndex, pageSize: 10);
            grid1.DataSource(dataSource, Grid1_fields);

            return UIHelper.Result();
        }


    }
}