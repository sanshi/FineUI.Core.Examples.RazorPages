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
    public class ColumnMoveOrderWidthHiddenModel : BaseModel
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


        #region Data

        private static readonly string KEY_FOR_DATASOURCE_SESSION = "GridMove.ColumnMoveOrderWidthHidden";

        // 模拟在服务器端保存数据
        // 特别注意：在真实的开发环境中，不要在Session放置大量数据，否则会严重影响服务器性能
        private JArray GetSavedColumns()
        {
            if (HttpContext.Session.GetObject<JArray>(KEY_FOR_DATASOURCE_SESSION) == null)
            {
                //[{
                //    "columnId": "RowNumber",
                //    "width": 30
                //}, {
                //    "columnId": "Name",
                //    "width": 100
                //}, {
                //    "columnId": "Gender",
                //    "width": 80
                //}, {
                //    "columnId": "EntranceYear",
                //    "width": 80
                //}, {
                //    "columnId": "AtSchool",
                //    "width": 80
                //}, {
                //    "columnId": "Major",
                //    "flex": 1
                //}, {
                //    "columnId": "LogTime",
                //    "width": 100
                //}]
                HttpContext.Session.SetObject(KEY_FOR_DATASOURCE_SESSION, JArray.Parse("[{\"columnId\":\"RowNumber\",\"width\":30},{\"columnId\":\"Name\",\"width\":100},{\"columnId\":\"Gender\",\"width\":80},{\"columnId\":\"EntranceYear\",\"width\":80},{\"columnId\":\"AtSchool\",\"width\":80},{\"columnId\":\"Major\",\"flex\":1},{\"columnId\":\"LogTime\",\"width\":100}]"));
            }
            return HttpContext.Session.GetObject<JArray>(KEY_FOR_DATASOURCE_SESSION);
        }


        #endregion

    }
}