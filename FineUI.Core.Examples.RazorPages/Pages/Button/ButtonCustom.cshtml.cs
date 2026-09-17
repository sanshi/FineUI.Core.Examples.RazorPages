using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Button
{
    public class ButtonCustomModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostButton1_Click()
        {
            ShowNotify("点击了普通按钮");

            return UIHelper.Result();
        }

        public IActionResult OnPostButton2_Click()
        {
            ShowNotify("点击了自定义按钮");

            return UIHelper.Result();
        }

    }
}