using Microsoft.AspNetCore.Mvc;
using System;

namespace FineUI.Core.Examples.RazorPages.Pages.Form
{
    public class CheckBoxClientServerEventModel : BaseModel
    {
        public void OnGet()
        {

        }


        public IActionResult OnPostCheckBox1_CheckedChanged(bool isChecked)
        {
            UIHelper.Label("labResult").Text("【服务端】复选框1的状态：" + (isChecked ? "选中" : "未选中"));

            return UIHelper.Result();
        }

        public IActionResult OnPostCheckBox2_CheckedChanged(bool isChecked)
        {
            UIHelper.Label("labResult").Text("【服务端】复选框2的状态：" + (isChecked ? "选中" : "未选中"));

            return UIHelper.Result();
        }


    }
}
