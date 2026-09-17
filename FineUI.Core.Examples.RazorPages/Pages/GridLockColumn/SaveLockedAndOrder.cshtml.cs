using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;

namespace FineUI.Core.Examples.RazorPages.Pages.GridLockColumn
{
    public class SaveLockedAndOrderModel : BaseModel
    {
        private static readonly JArray GRID_COLUMNCONFIG_DEFAULT = new JArray
        {
            new JObject {
                { "ColumnID", "RowNumber" },
                { "Locked", true }
            },
            new JObject {
                { "ColumnID", "Name" },
                { "Locked", true }
            },
            new JObject {
                { "ColumnID", "Gender" },
                { "Locked", false }
            },
            new JObject {
                { "ColumnID", "EntranceYear" },
                { "Locked", false }
            },
            new JObject {
                { "ColumnID", "AtSchool" },
                { "Locked", false }
            },
            new JObject {
                { "ColumnID", "Major" },
                { "Locked", false }
            },
            new JObject {
                { "ColumnID", "ShenGao" },
                { "Locked", false }
            },
            new JObject {
                { "ColumnID", "TiZhong" },
                { "Locked", false }
            },
            new JObject {
                { "ColumnID", "XueYaDi" },
                { "Locked", false }
            },
            new JObject {
                { "ColumnID", "XueYaGao" },
                { "Locked", false }
            },
            new JObject {
                { "ColumnID", "ShiLiZuo" },
                { "Locked", false }
            },
            new JObject {
                { "ColumnID", "ShiLiYou" },
                { "Locked", false }
            },
            new JObject {
                { "ColumnID", "Group" },
                { "Locked", false }
            },
            new JObject {
                { "ColumnID", "LogTime" },
                { "Locked", false }
            }
        };

        public void OnGet()
        {
            LoadData();


        }

        private void LoadData()
        {
            ViewBag.SavedColumns = GetSavedColumns();
        }

        public IActionResult OnPostGrid1_ColumnLockUnlock(JArray configedColumns)
        {
            HttpContext.Session.SetObject(KEY_FOR_DATASOURCE_SESSION, configedColumns);

            return UIHelper.Result();
        }


        #region Data

        private static readonly string KEY_FOR_DATASOURCE_SESSION = "GridLockColumn.SaveLockedAndOrder";

        // 模拟在服务器端保存数据
        // 特别注意：在真实的开发环境中，不要在Session放置大量数据，否则会严重影响服务器性能
        private JArray GetSavedColumns()
        {
            if (HttpContext.Session.GetObject<JArray>(KEY_FOR_DATASOURCE_SESSION) == null)
            {
                HttpContext.Session.SetObject(KEY_FOR_DATASOURCE_SESSION, GRID_COLUMNCONFIG_DEFAULT);
            }
            return HttpContext.Session.GetObject<JArray>(KEY_FOR_DATASOURCE_SESSION);
        }


        #endregion

    }
}