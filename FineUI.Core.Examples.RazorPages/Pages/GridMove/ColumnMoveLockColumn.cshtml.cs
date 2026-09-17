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
    public class ColumnMoveLockColumnModel : BaseModel
    {
        public void OnGet()
        {
            LoadData();


        }


        
        private void LoadData()
        {
            ViewBag.Grid1ColumnIDS = GetSavedColumnIds().ToObject<List<string>>();
            ViewBag.Grid1LockedColumnIDS = GetSavedLockedColumnIds().ToObject<List<string>>();
        }

        public IActionResult OnPostGrid1_ColumnMoveOrLock(JArray columnIds, JArray lockedColumnIds)
        {
            // 模拟操作数据库中的数据
            HttpContext.Session.SetObject(KEY_FOR_COLUMN_IDS_SESSION,  columnIds);

            HttpContext.Session.SetObject(KEY_FOR_LOCKED_COLUMN_IDS_SESSION, lockedColumnIds);

            return UIHelper.Result();
        }


        #region Data

        private static readonly string KEY_FOR_COLUMN_IDS_SESSION = "GridMove.ColumnMove.ColumnIds";

        // 模拟在服务器端保存数据
        // 特别注意：在真实的开发环境中，不要在Session放置大量数据，否则会严重影响服务器性能
        private JArray GetSavedColumnIds()
        {
            if (HttpContext.Session.GetObject<JArray>(KEY_FOR_COLUMN_IDS_SESSION) == null)
            {
                HttpContext.Session.SetObject(KEY_FOR_COLUMN_IDS_SESSION, new JArray());
            }
            return HttpContext.Session.GetObject<JArray>(KEY_FOR_COLUMN_IDS_SESSION);
        }

        private static readonly string KEY_FOR_LOCKED_COLUMN_IDS_SESSION = "GridMove.ColumnMove.LockedColumnIds";

        // 模拟在服务器端保存数据
        // 特别注意：在真实的开发环境中，不要在Session放置大量数据，否则会严重影响服务器性能
        private JArray GetSavedLockedColumnIds()
        {
            if (HttpContext.Session.GetObject<JArray>(KEY_FOR_LOCKED_COLUMN_IDS_SESSION) == null)
            {
                HttpContext.Session.SetObject(KEY_FOR_LOCKED_COLUMN_IDS_SESSION, new JArray());
            }
            return HttpContext.Session.GetObject<JArray>(KEY_FOR_LOCKED_COLUMN_IDS_SESSION);
        }


        #endregion

    }
}