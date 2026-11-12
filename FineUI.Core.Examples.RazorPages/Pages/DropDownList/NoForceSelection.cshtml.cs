using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.DropDownList
{
    public class NoForceSelectionModel : PageBase
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostBtnGetSelection_Click(string DropDownList1, string DropDownList1_text, bool DropDownList1_isUserInput)
        {
            var labResult = UIHelper.Label("labResult");

            if (!String.IsNullOrEmpty(DropDownList1))
            {
                // 用户输入按文字回显，先编码动态文字，避免结果区把输入当作 HTML 标签解析。
                labResult.Text(String.Format(
                    "选中项：{0}（值：{1}）",
                    HtmlEncode(DropDownList1_text),
                    HtmlEncode(DropDownList1)));
            }
            else
            {
                labResult.Text(String.IsNullOrEmpty(DropDownList1_text) ? "无选中项" : String.Format("用户输入值：{0}", HtmlEncode(DropDownList1_text)));
            }

            return UIHelper.Result();
        }

        public IActionResult OnPostBtnSelectItem6_Click()
        {
            UIHelper.DropDownList("DropDownList1").SelectedValue("Value6");

            return UIHelper.Result();
        }

    }
}