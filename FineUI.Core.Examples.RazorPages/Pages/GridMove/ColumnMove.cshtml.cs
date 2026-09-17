using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using Newtonsoft.Json.Linq;


namespace FineUI.Core.Examples.RazorPages.Pages.GridMove
{
    public class ColumnMoveModel : BaseModel
    {
        public void OnGet()
        {
            LoadData();


        }


        
        private void LoadData()
        {
            ViewBag.Grid1ColumnIDS = GetSavedColumns();
        }


        public IActionResult OnPostGrid1_ColumnMove(JArray columnIds)
        {
            // 模拟操作数据库中的数据
            HttpContext.Session.SetObject(KEY_FOR_DATASOURCE_SESSION, columnIds);

            return UIHelper.Result();
        }


        public IActionResult OnPostBtnClearData_Click()
        {
            UIHelper.Grid("Grid1").DataSource(null);

            return UIHelper.Result();
        }

        public IActionResult OnPostBtnRebindData_Click(string[] Grid1_fields)
        {
            UIHelper.Grid("Grid1").DataSource(DataSourceUtil.GetDataTable2(), Grid1_fields);

            return UIHelper.Result();
        }


        #region Data

        private static readonly string KEY_FOR_DATASOURCE_SESSION = "GridMove.ColumnMove";

        // 模拟在服务器端保存数据
        // 特别注意：在真实的开发环境中，不要在Session放置大量数据，否则会严重影响服务器性能
        private JArray GetSavedColumns()
        {
            if (HttpContext.Session.GetObject<JArray>(KEY_FOR_DATASOURCE_SESSION) == null)
            {
                HttpContext.Session.SetObject(KEY_FOR_DATASOURCE_SESSION, new JArray());
            }
            return HttpContext.Session.GetObject<JArray>(KEY_FOR_DATASOURCE_SESSION);
        }


        #endregion
    }
}