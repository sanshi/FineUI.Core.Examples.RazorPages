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
    public class TagsCheckBoxListModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostBtnGetSelection_Click(string[] DropDownBox1, string DropDownBox1_text)
        {
            var labResult = UIHelper.Label("labResult");
            if (DropDownBox1 != null && DropDownBox1.Length > 0)
            {
                labResult.Text(String.Format("下拉框文本：{0}（值：{1}）", DropDownBox1_text, String.Join(", ", DropDownBox1)));
            }
            else
            {
                labResult.Text("下拉框为空");
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

    }
}