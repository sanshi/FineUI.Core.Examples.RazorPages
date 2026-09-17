using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Other
{
    public class NoConflictModel : BaseModel
    {
        public void OnGet()
        {
            
        }

        public IActionResult OnPostBtnEnable_Click()
        {
            ShowNotify("你点击了刚刚启用的按钮");

            return UIHelper.Result();
        }
        
        public IActionResult OnPostBtnChangeEnable_Click()
        {
            var btnEnable = UIHelper.Button("btnEnable");

            btnEnable.Enabled(true);
            btnEnable.Text("本按钮已经启用（点击弹出对话框）");

            //throw new Exception("异常信息");

            return UIHelper.Result();
        }
        
        public IActionResult OnPostBtnChangePressed_Click(bool pressed)
        {
            UIHelper.Button("btnPressed").Pressed(!pressed);

            return UIHelper.Result();
        }
        
        public IActionResult OnPostBtnTooltip_Click()
        {
            UIHelper.Button("btnTooltip").ToolTip("这是改变后的提示信息");

            return UIHelper.Result();
        }
    }
}