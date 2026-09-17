using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.DropDownList
{
    public class DropDownListModel : BaseModel
    {
        public void OnGet()
        {

        }



        public IActionResult OnPostBtnGetSelection_Click(string DropDownList1, string DropDownList1_text)
        {
            if (!String.IsNullOrEmpty(DropDownList1))
            {
                UIHelper.Label("labResult").Text(String.Format("选中项：{0}（值：{1}）", DropDownList1_text, DropDownList1));
            }
            else
            {
                UIHelper.Label("labResult").Text("无选中项");
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