using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Grid
{
    public class IFrameWindowModel : BaseThirdPartyEditorModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostBtnSaveClose_Click()
        {
            // 1. 这里放置保存窗体中数据的逻辑

            // 2. 关闭本窗体（触发窗体的关闭事件）
            ActiveWindow.HidePostBack();

            return UIHelper.Result();
        }

        public IActionResult OnPostBtnSaveHideRefresh_Click()
        {
            // 1. 这里放置保存窗体中数据的逻辑

            // 2. 隐藏本窗体，然后刷新父窗体
            ActiveWindow.HideRefresh();

            return UIHelper.Result();
        }

        public IActionResult OnPostBtnSaveCloseTab_Click()
        {
            // 1. 这里放置保存窗体中数据的逻辑

            // 2. 隐藏本窗体，然后执行JavaScript脚本（关闭当前激活的选项卡）
            ActiveWindow.HideInvokeFunction("removeActiveTab");

            return UIHelper.Result();
        }


    }
}