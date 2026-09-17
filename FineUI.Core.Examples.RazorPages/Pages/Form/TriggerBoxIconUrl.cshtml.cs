using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Form
{
    public class TriggerBoxIconUrlModel : BaseModel
    {
        public void OnGet()
        {

        }


        

        public IActionResult OnPostBtnCloseWindow_Click()
        {
            UIHelper.Window("Window1").Hide();
            UIHelper.TriggerBox("TriggerBox1").Text("弹出窗口被关闭了");

            return UIHelper.Result();
        }


        public IActionResult OnPostTwinTriggerBox1_Trigger2Click(string text)
        {
            // 点击 TwinTriggerBox 的搜索按钮
            var TwinTriggerBox1 = UIHelper.TwinTriggerBox("TwinTriggerBox1");

            if (!String.IsNullOrEmpty(text))
            {
                // 执行搜索动作
                ShowNotify(String.Format("在关键词“{0}”中搜索", text));

                TwinTriggerBox1.ShowTrigger1(true);
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
            var TwinTriggerBox1 = UIHelper.TwinTriggerBox("TwinTriggerBox1");

            ShowNotify("取消搜索！");

            // 执行清空动作
            TwinTriggerBox1.Text("");
            TwinTriggerBox1.ShowTrigger1(false);

            return UIHelper.Result();
        }


    }
}