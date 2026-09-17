using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Grid
{
    public class CheckFieldPostBackModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostGrid1_CheckFieldChanged(string rowId, string rowText, bool isChecked)
        {
            ShowNotify(String.Format("你点击了的行ID：{0}，姓名：{1}，是否在校：{2}", rowId, rowText, isChecked ? "是" : "否"));

            return UIHelper.Result();
        }

    }
}