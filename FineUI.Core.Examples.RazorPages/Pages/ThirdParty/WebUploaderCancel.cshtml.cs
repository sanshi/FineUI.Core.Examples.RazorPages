using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;

namespace FineUI.Core.Examples.RazorPages.Pages.ThirdParty
{
    public class WebUploaderCancelModel : BaseWebUploaderModel
    {
        private static readonly string KEY_FOR_DATASOURCE_SESSION = "webuploader.webuploader_cancel";

        public void OnGet()
        {
            ViewBag.Grid1DataSource = GetSourceData(KEY_FOR_DATASOURCE_SESSION);

        }

        public IActionResult OnPostGrid1_DeleteRow(string rowId, string[] Grid1_fields)
        {
            var grid1 = UIHelper.Grid("Grid1");

            DeleteRow(KEY_FOR_DATASOURCE_SESSION, rowId);
            grid1.DataSource(GetSourceData(KEY_FOR_DATASOURCE_SESSION), Grid1_fields);

            return UIHelper.Result();
        }

        public IActionResult OnPostGrid1_DeleteRows(string[] deletedRowIDs, string[] Grid1_fields)
        {
            var grid1 = UIHelper.Grid("Grid1");

            foreach (var rowId in deletedRowIDs)
            {
                DeleteRow(KEY_FOR_DATASOURCE_SESSION, rowId);
            }

            grid1.DataSource(GetSourceData(KEY_FOR_DATASOURCE_SESSION), Grid1_fields);

            return UIHelper.Result();
        }

        public IActionResult OnPostRebindGrid(string[] Grid1_fields)
        {
            var grid1 = UIHelper.Grid("Grid1");

            grid1.DataSource(GetSourceData(KEY_FOR_DATASOURCE_SESSION), Grid1_fields);

            return UIHelper.Result();
        }

    }
}
