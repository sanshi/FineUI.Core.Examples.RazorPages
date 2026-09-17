using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Message
{
    public class ConfirmButtonsModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostConfirmOK()
        {
            ShowNotify("你点击了[直接退出]按钮！");

            return UIHelper.Result();
        }

        public IActionResult OnPostConfirmCancel()
        {
            ShowNotify("你点击了[不退出]按钮！");

            return UIHelper.Result();
        }

    }
}