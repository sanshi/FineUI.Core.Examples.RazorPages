using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using Newtonsoft.Json.Linq;


namespace FineUI.Core.Examples.RazorPages.Pages.GridDataUrl
{
    public class RowButtonModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostGrid1_CustomEvent(string eventType, int rowIndex, string rowId, string rowText)
        {
            string eventTypeStr = String.Empty;
            if (eventType == "edit")
            {
                eventTypeStr = "编辑";
            }
            else if (eventType == "delete")
            {
                eventTypeStr = "删除";
            }

            ShowNotify(String.Format("你点击了第 {0} 行的 {3} 按钮，行ID：{1}，姓名：{2}", rowIndex + 1, rowId, rowText, eventTypeStr));

            return UIHelper.Result();
        }

    }
}