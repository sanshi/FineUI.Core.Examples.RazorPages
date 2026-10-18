using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Other
{
    public class AuthenticationTimeoutAsyncModel : PageBase
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostButton2_Click()
        {
            // 回发返回跳转命令，异步确认取消时可以阻止本次导航。
            FineUI.Core.PageContext.Redirect(Url.Content("~/?ReturnUrl=%2fOther%2fAuthenticationTimeoutAsync"));

            return UIHelper.Result();
        }

    }
}
