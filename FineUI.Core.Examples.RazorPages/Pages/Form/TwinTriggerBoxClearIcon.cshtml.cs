using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Form
{
    public class TwinTriggerBoxClearIconModel : BaseModel
    {
        public void OnGet()
        {

        }


        

        public IActionResult OnPostTwinTriggerBox1_Trigger2Click(string text)
        {
            // 点击 TwinTriggerBox 的搜索按钮
            if (!String.IsNullOrEmpty(text))
            {
                // 执行搜索动作
                ShowNotify(String.Format("在关键词“{0}”中搜索", text));
                
                UpdateClientJSParameter(text);
            }
            else
            {
                ShowNotify("请输入你要搜索的关键词！");
            }

            return UIHelper.Result();
        }


        public IActionResult OnPostTwinTriggerBox1_Trigger1Click()
        {
            // 点击 TwinTriggerBox 的取消按钮
            ShowNotify("取消搜索！");

            UpdateClientJSParameter("");

            return UIHelper.Result();
        }


        // 更新客户端变量
        private void UpdateClientJSParameter(string text)
        {
            RegisterStartupScript(String.Format("updateLastTriggerBoxValue({0});", JsHelper.Enquote(text)));
        }

    }
}