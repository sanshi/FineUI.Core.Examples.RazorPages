using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.DropDownList
{
    public class MultiSelectTagsNoForceSelectionInitValueModel : BaseModel
    {
        public void OnGet()
        {
            ViewBag.DropDownList1Text = "可选项1, 可选项4, 初始自定义值1";
            ViewBag.DropDownList1SelectedValueArray = new string[] { "Value1", "Value4", "__USERINPUT_value1" };

        }


        
        public IActionResult OnPostBtnGetSelection_Click(string[] DropDownList1, string DropDownList1_text, bool DropDownList1_isUserInput)
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

        public IActionResult OnPostBtnSelectItem6_Click()
        {
            UIHelper.DropDownList("DropDownList1").SelectedValue("Value6");

            return UIHelper.Result();
        }


    }
}