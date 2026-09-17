using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Form
{
    public class HtmlEditorModel : BaseModel
    {
        public void OnGet()
        {
            ViewBag.InitContent = "FineUI.Pro<br>基于 jQuery 的专业 ASP.NET 控件库。<br><br>FineUI的使命<br>创建 No JavaScript，No CSS，No UpdatePanel，No ViewState，No WebServices 的网站应用程序。<br><br>支持的浏览器<br>IE 8.0+、Chrome、Firefox、Opera、Safari<br><br>授权协议<br>商业授权<br><br>相关链接<br>论坛：<a href=\"http://fineui.com/bbs/\">http://fineui.com/bbs/</a><br>示例：<a href=\"https://fineui.com/pro/demo/\">https://fineui.com/pro/demo/</a><br><br>";
        }


        
        public IActionResult OnPostButton1_Click(string content)
        {
            UIHelper.TextArea("TextArea1").Text(content);

            return UIHelper.Result();
        }

        public IActionResult OnPostButton2_Click(string content)
        {
            UIHelper.HtmlEditor("HtmlEditor1").Text(content);

            return UIHelper.Result();
        }

    }
}