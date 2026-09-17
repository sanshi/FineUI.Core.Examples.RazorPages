using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Mobile.Message
{
    public class PromptModel : BaseMobileModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostButton1_Click()
        {
            Prompt prompt = new Prompt();
            prompt.Message = "请输入你的姓名？";
            prompt.Title = "请输入";
            prompt.OkScript = "notifyit(arguments[0]);";
            prompt.Show();

            return UIHelper.Result();
        }

        public IActionResult OnPostButton2_Click()
        {
            Prompt prompt = new Prompt();
            prompt.Message = "请输入你的姓名？";
            prompt.Title = "请输入";
            prompt.OkScript = "notifyit(arguments[0]);";
            prompt.TitleAlign = TextAlign.Center;
            prompt.EnableClose = false;
            prompt.ButtonFill = true;
            prompt.Show();

            return UIHelper.Result();
        }

        public IActionResult OnPostButton3_Click()
        {
            Prompt prompt = new Prompt();
            prompt.Message = "请输入你的姓名？";
            prompt.Title = "请输入";
            prompt.OkScript = "notifyit(arguments[0]);";
            prompt.TitleAlign = TextAlign.Center;
            prompt.EnableClose = false;
            prompt.ButtonPlain = true;
            prompt.CancelButtonAhead = true;
            prompt.Show();

            return UIHelper.Result();
        }

        public IActionResult OnPostButton4_Click()
        {
            Prompt prompt = new Prompt();
            prompt.Message = "请输入你的密码？";
            prompt.Title = "请输入";
            prompt.OkScript = "notifyit(arguments[0]);";
            prompt.TitleAlign = TextAlign.Center;
            prompt.EnableClose = false;
            prompt.ButtonPlain = true;
            prompt.TextMode = TextMode.Password;
            prompt.Show();

            return UIHelper.Result();
        }

        public IActionResult OnPostButton5_Click()
        {
            Prompt prompt = new Prompt();
            prompt.Message = "请输入你的姓名？";
            prompt.Title = "请输入";
            prompt.OkScript = "notifyit(arguments[0]);";
            prompt.TitleAlign = TextAlign.Center;
            prompt.EnableClose = false;
            prompt.ButtonPlain = true;
            prompt.Show();

            return UIHelper.Result();
        }

    }
}