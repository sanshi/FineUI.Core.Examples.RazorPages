using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Grid
{
    public class RowSelectModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostGrid1_RowSelect(string rowId, string rowText, int rowIndex, string columnText, bool isDeselect)
        {
            string typeName = isDeselect ? "取消选中" : "选中";

            ShowNotify(String.Format("你" + typeName + "了第 {0} 行，行ID：{1}，姓名：{2}，列：{3}",
                rowIndex + 1, rowId, rowText, columnText));

            return UIHelper.Result();
        }

    }
}