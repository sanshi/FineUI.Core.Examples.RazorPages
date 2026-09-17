using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Mobile.Message
{
    public class NotifyModel : BaseMobileModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostButton1_Click()
        {
            Notify notify = new Notify();
            notify.Message = "数据保存成功！";
            notify.Title = "通知";
            notify.Show();

            return UIHelper.Result();
        }

        public IActionResult OnPostButton2_Click()
        {
            Notify notify = new Notify();
            notify.Message = "正在加载...";
            notify.MessageBoxIcon = MessageBoxIcon.None;
            notify.ShowHeader = false;
            notify.ShowLoading = true;
            notify.PositionX = Position.Center;
            notify.PositionY = Position.Center;
            notify.MinWidth = 0;
            notify.IsModal = true;
            notify.HideOnMaskClick = true;
            notify.Show();

            return UIHelper.Result();
        }

        public IActionResult OnPostButton3_Click()
        {
            Notify notify = new Notify();
            notify.CssClass = "mynotify-notext";
            notify.MessageBoxIcon = MessageBoxIcon.None;
            notify.ShowHeader = false;
            notify.ShowLoading = true;
            notify.PositionX = Position.Center;
            notify.PositionY = Position.Center;
            notify.MinWidth = 0;
            notify.IsModal = true;
            notify.HideOnMaskClick = true;
            notify.DisplayMilliseconds = 1000000;
            notify.Show();

            return UIHelper.Result();
        }

        public IActionResult OnPostButton4_Click()
        {
            Notify notify = new Notify();
            notify.CssClass = "mynotify";
            notify.MessageRawHtml = new RawHtml("<div class=\"f-loading\"><div class=\"f-loading-img\"><img src=\"{0}\"/></div></div><div class=\"f-loading-message\">正在加载</div>",
                FineUI.Core.PageContext.ResolveUrl("~/res/images/loading/loading_32.gif"));
            notify.MessageBoxIcon = MessageBoxIcon.None;
            notify.ShowHeader = false;
            notify.PositionX = Position.Center;
            notify.PositionY = Position.Center;
            notify.MinWidth = 0;
            notify.IsModal = true;
            notify.HideOnMaskClick = true;
            notify.DisplayMilliseconds = 1000000;
            notify.Show();

            return UIHelper.Result();
        }

    }
}