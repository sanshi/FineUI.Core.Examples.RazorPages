using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.DropDownList
{
    public class EmptyTextModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostBtnSelectItem6_Click()
        {
            UIHelper.DropDownList("DropDownList1").SelectedValue("Value6");

            return UIHelper.Result();
        }

        public IActionResult OnPostBtnGetSelection_Click(string DropDownList1, string DropDownList1_text)
        {
            ShowResult(DropDownList1, DropDownList1_text);

            return UIHelper.Result();
        }


        private void ShowResult(string value, string text)
        {
            var labResult = UIHelper.Label("labResult");

            if (!String.IsNullOrEmpty(text))
            {
                labResult.Text(String.Format("选中项：{0}（值：{1}）", text, value));
            }
            else
            {
                labResult.Text("无选中项");
            }
        }

    }
}