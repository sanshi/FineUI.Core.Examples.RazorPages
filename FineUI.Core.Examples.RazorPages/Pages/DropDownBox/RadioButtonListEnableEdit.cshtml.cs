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
    public class RadioButtonListEnableEditModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostBtnGetSelection_Click(string DropDownBox1, string DropDownBox1_text, bool DropDownBox1_isUserInput)
        {
            var labResult = UIHelper.Label("labResult");
            if (!String.IsNullOrEmpty(DropDownBox1))
            {
                labResult.Text(String.Format("下拉框文本：{0}（值：{1}）", DropDownBox1_text, DropDownBox1));
            }
            else
            {
                labResult.Text(String.Format("用户输入值：{0}", DropDownBox1_text));
            }

            return UIHelper.Result();
        }

    }
}