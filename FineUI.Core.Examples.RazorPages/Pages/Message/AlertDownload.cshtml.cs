using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Message
{
    public class AlertDownloadModel : BaseModel
    {
        public void OnGet()
        {

        }
        

        public IActionResult OnPostConfirmCancel()
        {
            ShowNotify("点击了取消按钮！");

            return UIHelper.Result();
        }


        public IActionResult OnPostBtnOperation_Click()
        {
            new Confirm
            {
                Message = "操作成功！点击确定按钮开始下载文件，点取消按钮弹出对话框",
                MessageBoxIcon = MessageBoxIcon.Question,
                OkFunction = "confirmOKCallback",
                CancelFunction = "confirmCancelCallback"
            }.Show();

            return UIHelper.Result();
        }

    }
}