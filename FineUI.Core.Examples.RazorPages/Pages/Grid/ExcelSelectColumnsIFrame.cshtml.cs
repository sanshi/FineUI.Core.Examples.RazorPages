using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;

namespace FineUI.Core.Examples.RazorPages.Pages.Grid
{
    public class ExcelSelectColumnsIFrame : BaseModel
    {
        public void OnGet()
        {

        }

        public IActionResult OnPostSelectColumnsIFrame_btnSaveContinue_Click(string[] columns)
        {
            // 关闭弹出窗体，然后执行父页面的JavaScript函数（exportToExcel）并传入参数
            ActiveWindow.HideExecuteScript(String.Format("exportToExcel({0});", new JArray(columns).ToString(Newtonsoft.Json.Formatting.None)));

            return UIHelper.Result();
        }

    }
}