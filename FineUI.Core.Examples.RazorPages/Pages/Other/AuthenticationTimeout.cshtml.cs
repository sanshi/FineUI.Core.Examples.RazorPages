using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Other
{
    public class AuthenticationTimeoutModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostButton2_Click()
        {
            Response.Redirect(Url.Content("~/?ReturnUrl=%2fOther%2fAuthenticationTimeout"));

            return UIHelper.Result();
        }

    }
}