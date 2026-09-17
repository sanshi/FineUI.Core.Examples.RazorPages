using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Message
{
    public class ConfirmCancelModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostBtnOperation1_Click()
        {
            ShowNotify("执行了操作一！");

            return UIHelper.Result();
        }

        public IActionResult OnPostBtnOperation2_Click()
        {
            ShowNotify("执行了操作二！");

            return UIHelper.Result();
        }

        public IActionResult OnPostBtnOperation3_Click(string opType)
        {
            if (opType == "cancel")
            {
                ShowNotify("取消执行操作三！");
            }
            else
            {
                ShowNotify("执行了操作三！");
            }

            return UIHelper.Result();
        }
    }
}