using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Other
{
    public class FormAjaxCompleteModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostOnForm1Submit(IFormCollection values)
        {
            // 为了观察前台动画，后台休眠 1 秒钟
            System.Threading.Thread.Sleep(1000);

            ShowNotify(values);

            return UIHelper.Result();
        }


    }
}