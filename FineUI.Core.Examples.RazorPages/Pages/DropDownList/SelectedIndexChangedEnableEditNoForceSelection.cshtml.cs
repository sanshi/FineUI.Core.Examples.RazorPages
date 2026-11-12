using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.DropDownList
{
    public class SelectedIndexChangedEnableEditNoForceSelectionModel : PageBase
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostBtnGetSelection_Click(string DropDownList1, string DropDownList1_text, bool DropDownList1_isUserInput)
        {
            ShowResult(DropDownList1, DropDownList1_text);

            return UIHelper.Result();
        }

        public IActionResult OnPostDropDownList1_SelectedIndexChanged(string DropDownList1, string DropDownList1_text, bool DropDownList1_isUserInput)
        {
            ShowResult(DropDownList1, DropDownList1_text);

            return UIHelper.Result();
        }

        private void ShowResult(string value, string text)
        {
            var labResult = UIHelper.Label("labResult");

            if (!String.IsNullOrEmpty(value))
            {
                // 用户输入按文字回显，先编码动态文字，避免结果区把输入当作 HTML 标签解析。
                labResult.Text(String.Format(
                    "选中项：{0}（值：{1}）",
                    HtmlEncode(text),
                    HtmlEncode(value)));
            }
            else
            {
                labResult.Text(String.Format("用户输入值：{0}", HtmlEncode(text)));
            }
        }


        public IActionResult OnPostBtnSelectItem6_Click()
        {
            UIHelper.DropDownList("DropDownList1").SelectedValue("Value6");

            return UIHelper.Result();
        }

    }
}