using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Mobile.Message
{
    public class AlertModel : BaseMobileModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostButton1_Click()
        {
            Alert alert = new Alert();
            alert.Message = "这是提示对话框的内容！";
            alert.Title = "标题文字";
            alert.MessageBoxIcon = MessageBoxIcon.Information;
            alert.Show();

            return UIHelper.Result();
        }

        public IActionResult OnPostButton2_Click()
        {
            Alert alert = new Alert();
            alert.Message = "这是提示对话框的内容！";
            alert.Title = "标题文字";
            alert.TitleAlign = TextAlign.Center;
            alert.EnableClose = false;
            alert.ButtonFill = true;
            alert.Show();

            return UIHelper.Result();
        }

        public IActionResult OnPostButton3_Click()
        {
            Alert alert = new Alert();
            alert.Message = "这是提示对话框的内容！";
            alert.Title = "标题文字";
            alert.TitleAlign = TextAlign.Center;
            alert.EnableClose = false;
            alert.ButtonPlain = true;
            alert.Show();

            return UIHelper.Result();
        }

    }
}