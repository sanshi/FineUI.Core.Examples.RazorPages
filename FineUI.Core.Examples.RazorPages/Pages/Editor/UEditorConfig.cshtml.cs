using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Editor
{
    public class UEditorConfigModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostButton1_Click(string text)
        {
            if (String.IsNullOrEmpty(text))
            {
                ShowNotify("编辑器内容为空！");
            }
            else
            {
                ShowNotify(text);
            }

            return UIHelper.Result();
        }

        public IActionResult OnPostButton2_Click()
        {
            UIHelper.HtmlEditor("HtmlEditor1").Text("<p><strong>FineUI.Core</strong> - .NET 企业级全栈 UI 框架。</p>");

            return UIHelper.Result();
        }

    }
}