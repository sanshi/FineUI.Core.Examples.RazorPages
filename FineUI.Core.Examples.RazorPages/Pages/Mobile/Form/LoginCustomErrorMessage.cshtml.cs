using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

namespace FineUI.Core.Examples.RazorPages.Pages.Mobile.Form
{
    public class LoginCustomErrorMessageModel : BaseMobileModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostBtnLogin_Click(IFormCollection values)
        {
            if (values["tbxPassword"] == "admin")
            {
                ShowNotify("成功登录！", MessageBoxIcon.Success);
            }
            else
            {
                ShowNotify("用户名或密码错误！", MessageBoxIcon.Error);
            }

            return UIHelper.Result();
        }

    }
}