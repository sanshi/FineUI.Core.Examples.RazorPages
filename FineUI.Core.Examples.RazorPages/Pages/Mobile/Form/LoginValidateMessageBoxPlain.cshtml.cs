using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;


namespace FineUI.Core.Examples.RazorPages.Pages.Mobile.Form
{
    public class LoginValidateMessageBoxPlainModel : BaseMobileModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostBtnLogin_Click(IFormCollection values)
        {
            if (values["tbxUserName"] == "admin" && values["tbxPassword"] == "admin")
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