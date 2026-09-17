using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Message
{
    public class AlertCustomIconModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostBtnHello_Click()
        {
            Alert alert = new Alert();
            alert.Message = "你好 FineUI.Core！";
            alert.Icon = Icon.Book;
            alert.Show();

            return UIHelper.Result();
        }

        public IActionResult OnPostBtnHello2_Click()
        {
            Alert alert = new Alert();
            alert.Message = "你好 FineUI.Core！";
            alert.IconUrl = "~/res/images/success.png";
            alert.Target = Target.Top;
            alert.Show();

            return UIHelper.Result();
        }

        public IActionResult OnPostBtnHello3_Click()
        {
            Alert alert = new Alert();
            alert.Message = "你好 FineUI.Core！";
            alert.IconFont = IconFont._Car;
            alert.Target = Target.Top;
            alert.Show();

            return UIHelper.Result();
        }

    }
}