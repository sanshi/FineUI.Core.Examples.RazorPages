using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

namespace FineUI.Core.Examples.RazorPages.Pages.Form
{
    public class FormValidateBlurModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostBtnRegister_Click(IFormCollection values)
        {
            string userName = values["tbxUserName"];

            if (ValidateForm(userName))
            {
                ShowNotify(values);
            }

            return UIHelper.Result();
        }


        public IActionResult OnPostTbxUserName_Blur(string userName)
        {
            if (ValidateForm(userName))
            {
                // 用户名失去焦点，并且用户名有效，则聚焦到下一个控件
                UIHelper.TextBox("tbxPassword").Focus(true);
            }

            return UIHelper.Result();
        }
        

        private bool ValidateForm(string userName)
        {
            var tbxUserName = UIHelper.TextBox("tbxUserName");

            if (userName == "admin")
            {
                tbxUserName.MarkInvalid(String.Format("{0} 是保留字，请另外选择！", userName));
                return false;
            }
            else
            {
                tbxUserName.ClearInvalid();
                return true;
            }
        }
 

    }
}