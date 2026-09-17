using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Button
{
    public class ButtonClickModel : BaseModel
    {
        public IActionResult OnPostBtnServerClick_Click()
        {
            ShowNotify("这是服务器端事件");

            return UIHelper.Result();
        }

        public IActionResult OnPostBtnChangeClientClick2_Click()
        {
            // 回发中换掉客户端回调：下发的也只是新函数名，不是脚本
            UIHelper.Button("btnClientClick2").ClickHandler("onChangedClick");

            return UIHelper.Result();
        }


    }
}