using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Other
{
    public class CustomPostbackModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostTextBox1_ENTER(string text1)
        {
            var textBox2 = UIHelper.TextBox("TextBox2");

            textBox2.Text(text1);
            textBox2.Focus(true);

            return UIHelper.Result();
        }

    }
}