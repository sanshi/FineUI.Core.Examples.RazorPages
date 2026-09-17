using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Form
{
    public class FormValidateValidatorModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostBtnRegister_Click(string userName, string password)
        {
            ShowNotify(String.Format("用户名：{0} 密码：{1}", userName, password));

            return UIHelper.Result();
        }

    }
}