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
    public class CheckBoxListEnableEditDefaultModel : BaseModel
    {
        public void OnGet()
        {
            // 设置下拉框的初始值为自定义文本
            ViewBag.DropDownBox1Text = "初始自定义值";
        }


        
        public IActionResult OnPostBtnGetSelection_Click(string[] DropDownBox1, string DropDownBox1_text, bool DropDownBox1_isUserInput)
        {
            var labResult = UIHelper.Label("labResult");
			if (DropDownBox1 != null && DropDownBox1.Length > 0)
			{
                labResult.Text(String.Format("下拉框文本：{0}（值：{1}）", DropDownBox1_text, String.Join(", ", DropDownBox1)));
            }
            else
            {
                labResult.Text(String.Format("用户输入值：{0}", DropDownBox1_text));
            }

            return UIHelper.Result();
        }


        public IActionResult OnPostBtnSelectItem6_Click()
        {
            var DropDownBox1 = UIHelper.DropDownBox("DropDownBox1");

            // 后台更新下拉框的值，需要同时设置Text和Value
            DropDownBox1.Values(new string[] { "php", "basic" }, new string[] { "PHP", "Basic" });

            return UIHelper.Result();
        }


        public IActionResult OnPostBtnSetText_Click()
        {
            var DropDownBox1 = UIHelper.DropDownBox("DropDownBox1");

            // 后台更新下拉框的值，需要同时设置Text和Value
            DropDownBox1.Values(new string[0], "用户输入值");

            return UIHelper.Result();
        }

    }
}