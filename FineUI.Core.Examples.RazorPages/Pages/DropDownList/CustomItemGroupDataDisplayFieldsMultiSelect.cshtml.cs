using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.DropDownList
{
    public class CustomItemGroupDataDisplayFieldsMultiSelectModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostBtnGetSelection_Click(string[] DropDownList1, string DropDownList1_text)
        {
            var labResult = UIHelper.Label("labResult");

            if (!String.IsNullOrEmpty(DropDownList1_text))
            {
                labResult.Text(String.Format("选中项文本：{0}<br/>选中项值：{1}", DropDownList1_text, String.Join(", ", DropDownList1)));
            }
            else
            {
                labResult.Text("无选中项");
            }


            return UIHelper.Result();
        }

    }
}