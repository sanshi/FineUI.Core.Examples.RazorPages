using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Grid
{
    public class RowCommandCustomModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostGrid1_RowCommand(string rowId, string rowText, int rowIndex, int columnIndex)
        {
            ShowNotify(String.Format("你点击了第 {0} 行，第 {1} 列，行ID：{2}，姓名：{3}",
                rowIndex + 1, columnIndex + 1, rowId, rowText));

            return UIHelper.Result();
        }

    }
}