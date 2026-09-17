using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Form
{
    public class TextBoxModel : BaseModel
    {
        public void OnGet()
        {
            
        }


        
        public IActionResult OnPostBtnSubmit_Click(string userName, string password)
        {
            UIHelper.Label("labResult").Text("用户名：" + userName + " 密码：" + password);

            return UIHelper.Result();
        }

    }
}