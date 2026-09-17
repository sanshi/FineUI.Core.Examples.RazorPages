using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Message
{
    public class NotifyAddTabModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostBtnOperation1_Click()
        {
            // 随机生成通知对话框的客户端ID
            string notifyId = Guid.NewGuid().ToString();

            Notify n = new Notify();
            n.ID = notifyId;
            n.MessageRawHtml = new RawHtml("<div class=\"addtabcontainer\"><a href=\"javascript:openExampleHello('" + notifyId + "');\">向父页面添加选项卡</a></div>");
            n.MessageBoxIcon = MessageBoxIcon.None;
            n.PositionX = Position.Right;
            n.PositionY = Position.Bottom;
            n.DisplayMilliseconds = 0;
            n.ShowHeader = false;

            n.Show();

            return UIHelper.Result();
        }

    }
}