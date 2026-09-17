using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Mobile.Message
{
    public class ConfirmModel : BaseMobileModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostButton1_Click()
        {
            Confirm confirm = new Confirm();
            confirm.Message = "您真的要执行删除操作吗？";
            confirm.Title = "确认操作";
            confirm.MessageBoxIcon = MessageBoxIcon.Question;
            confirm.Show();

            return UIHelper.Result();
        }

        public IActionResult OnPostButton2_Click()
        {
            Confirm confirm = new Confirm();
            confirm.Message = "您真的要执行删除操作吗？";
            confirm.Title = "确认操作";
            confirm.TitleAlign = TextAlign.Center;
            confirm.EnableClose = false;
            confirm.ButtonFill = true;
            confirm.Show();

            return UIHelper.Result();
        }

        public IActionResult OnPostButton3_Click()
        {
            Confirm confirm = new Confirm();
            confirm.Message = "您真的要执行删除操作吗？";
            confirm.Title = "确认操作";
            confirm.TitleAlign = TextAlign.Center;
            confirm.EnableClose = false;
            confirm.ButtonPlain = true;
            confirm.CancelButtonAhead = true;
            confirm.Show();

            return UIHelper.Result();
        }

        public IActionResult OnPostButton6_Click()
        {
            Confirm confirm = new Confirm();
            confirm.Message = "您真的要执行删除操作吗？";
            confirm.Title = "确认操作";
            confirm.TitleAlign = TextAlign.Center;
            confirm.EnableClose = false;
            confirm.ButtonPlain = true;
            confirm.Show();

            return UIHelper.Result();
        }


        public IActionResult OnPostButton4_ConfirmResult(string button)
        {
            ShowNotify(String.Format("你点击了 Button4 对话框的 {0} 按钮", button));

            return UIHelper.Result();
        }


        public IActionResult OnPostButton5_ConfirmResult(string button)
        {
            ShowNotify(String.Format("你点击了 Button5 对话框的 {0} 按钮", button));

            return UIHelper.Result();
        }

    }
}