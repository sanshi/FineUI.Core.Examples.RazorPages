using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Other
{
    public class AuthenticationTimeoutModel : PageBase
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostButton2_Click()
        {
            // 回发返回跳转命令，页面的 beforeAjaxSuccess 可先询问用户是否继续。
            FineUI.Core.PageContext.Redirect(Url.Content("~/?ReturnUrl=%2fOther%2fAuthenticationTimeout"));

            return UIHelper.Result();
        }

    }
}
