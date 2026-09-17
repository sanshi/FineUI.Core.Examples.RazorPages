using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Editor
{
    public class UMEditorTwoModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostButton1_Click(string title, string text1, string text2)
        {
            if (String.IsNullOrEmpty(text1))
            {
                ShowNotify("文章正文不能为空！");
            }
            else
            {
                ShowNotify(new RawHtml("文章标题：{0}<br/>文章正文：{1}<br/>文章摘要：{2}", HttpUtility.HtmlEncode(title), HttpUtility.HtmlEncode(text1), HttpUtility.HtmlEncode(text2)));
            }

            return UIHelper.Result();
        }

        public IActionResult OnPostButton2_Click(string text1)
        {
            Regex regex = new Regex(@"<[^>]+>|</[^>]+>");
            string content = regex.Replace(text1, "");
            if (content.Length > 100)
            {
                content = content.Substring(0, 97) + "...";
            }

            UIHelper.HtmlEditor("HtmlEditor2").Text(content);

            return UIHelper.Result();
        }
    }
}