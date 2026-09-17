using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Form
{
    public class TextBoxTextChangedModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostTextBox1_TextChanged(string text)
        {
            UIHelper.Label("labResult1").Text("文本框一：" + text);

            return UIHelper.Result();
        }

        public IActionResult OnPostTextBox2_Blur(string text)
        {
            UIHelper.Label("labResult2").Text("文本框二：" + text);

            return UIHelper.Result();
        }

    }
}