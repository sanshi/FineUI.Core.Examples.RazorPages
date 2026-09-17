using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Other
{
    public class CssStyleModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostButton1_Click()
        {
            Random rd = new Random();
            string styles = String.Format("font-size:1.5em;font-weight:bold;color:rgb({0},{1},{2});", rd.Next(256), rd.Next(256), rd.Next(256));

            UIHelper.Label("Label1").ApplyStyles(styles);

            return UIHelper.Result();
        }

        public IActionResult OnPostButton3_Click()
        {
            // 不能直接设置 CssStyle=String.Empty，客户端只会覆盖相同CSS属性的样式，而不会清空元素的 style 属性
            // 需要注册JavaScript脚本来清空元素的 style 属性
            RegisterStartupScript("F.ui.Label1.el.attr('style','');");

            return UIHelper.Result();
        }

        


        public IActionResult OnPostButton2_Click(bool hasClassRed)
        {
            var label2 = UIHelper.Label("Label2");

            if (hasClassRed)
            {
                label2.RemoveCssClass("red");
                label2.AddCssClass("green");
            }
            else
            {
                label2.RemoveCssClass("green");
                label2.AddCssClass("red");
            }

            return UIHelper.Result();
        }

        public IActionResult OnPostButton4_Click()
        {
            var label2 = UIHelper.Label("Label2");
            label2.RemoveCssClass("red");
            label2.RemoveCssClass("green");

            return UIHelper.Result();
        }
    }
}