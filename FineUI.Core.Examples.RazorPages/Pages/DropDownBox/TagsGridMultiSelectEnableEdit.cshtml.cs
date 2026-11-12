using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using Newtonsoft.Json.Linq;


namespace FineUI.Core.Examples.RazorPages.Pages.DropDownBox
{
    public class TagsGridMultiSelectEnableEditModel : PageBase
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostBtnGetSelection_Click(string[] DropDownBox1, string DropDownBox1_text, bool DropDownBox1_isUserInput)
        {
            var labResult = UIHelper.Label("labResult");
            if (DropDownBox1 != null && DropDownBox1.Length > 0)
            {
                // 用户输入按文字回显，先编码动态文字，避免结果区把输入当作 HTML 标签解析。
                labResult.Text(String.Format(
                    "下拉框文本：{0}（值：{1}）",
                    HtmlEncode(DropDownBox1_text),
                    HtmlEncode(String.Join(", ", DropDownBox1))));
            }
            else
            {
                labResult.Text(String.Format("用户输入值：{0}", HtmlEncode(DropDownBox1_text)));
            }

            return UIHelper.Result();
        }


    }
}