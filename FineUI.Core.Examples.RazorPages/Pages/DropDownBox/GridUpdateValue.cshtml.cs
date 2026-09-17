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
    public class GridUpdateValueModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostBtnUpdateValue_Click()
        {
            // 1. 对于未分页的表格，可以不设置 Text 属性，以便客户端重新计算
            // 2. 对于分页的表格，一定要手工设置 Text 属性，否则客户端无法取到 Value 对应的 Text 属性
            UIHelper.DropDownBox("DropDownBox1").Value("112");

            return UIHelper.Result();
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

    }
}