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
    public class GridTextChangedModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostDropDownBox1_TextChanged(string[] DropDownBox1, string DropDownBox1_text)
        {
            ShowResult(DropDownBox1, DropDownBox1_text);

            return UIHelper.Result();
        }

        public IActionResult OnPostBtnGetSelection_Click(string[] DropDownBox1, string DropDownBox1_text)
        {
            ShowResult(DropDownBox1, DropDownBox1_text);

            return UIHelper.Result();
        }


        private static void ShowResult(string[] DropDownBox1, string DropDownBox1_text)
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
        }

    }
}