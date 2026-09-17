using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Grid
{
    public class IFrameWindowModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostBtnSaveClose_Click()
        {
            // 1. 这里放置保存窗体中数据的逻辑

            // 2. 关闭本窗体（触发窗体的关闭事件）
            RegisterStartupScript(ActiveWindow.GetHidePostBackReference());

            return UIHelper.Result();
        }

        public IActionResult OnPostBtnSaveHideRefresh_Click()
        {
            // 1. 这里放置保存窗体中数据的逻辑

            // 2. 隐藏本窗体，然后刷新父窗体
            RegisterStartupScript(ActiveWindow.GetHideRefreshReference());

            return UIHelper.Result();
        }

        public IActionResult OnPostBtnSaveCloseTab_Click()
        {
            // 1. 这里放置保存窗体中数据的逻辑

            // 2. 隐藏本窗体，然后执行JavaScript脚本（关闭当前激活的选项卡）
            RegisterStartupScript(ActiveWindow.GetHideExecuteScriptReference("parent.removeActiveTab();"));

            return UIHelper.Result();
        }


    }
}