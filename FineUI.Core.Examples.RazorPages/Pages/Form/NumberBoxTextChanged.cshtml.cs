using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Form
{
    public class NumberBoxTextChangedModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostNumberBox3_TextChanged(string text)
        {
            ShowNotify("数字输入框的值（NumberBox3_TextChanged）：" + text);

            return UIHelper.Result();
        }

        public IActionResult OnPostBtnSubmit_Click(string text)
        {
            ShowNotify("数字输入框的值（btnSubmit_Click）：" + text);

            return UIHelper.Result();
        }


    }
}