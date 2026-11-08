using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace FineUI.Core.Examples.RazorPages.Pages.HtmlEditor
{
    public class FormattingModel : PageBase
    {
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
