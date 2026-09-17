using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Other
{
    public class CustomPostbackJsonModel : BaseModel
    {
        public void OnGet()
        {

        }



        public IActionResult OnPostTextBox1_ENTER(string text1)
        {
            return new JsonResult(new { type = "enter", text = text1 + " - server" });
        }

    }
}