using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FineUI.Core.Examples.RazorPages.Pages.DataModel.Models;

namespace FineUI.Core.Examples.RazorPages.Pages.DataModel
{
    public class LoginModelModel : BaseModel
    {
        public void OnGet()
        {
            //CurrentUser = new User { 
            //    UserName = "<b>BBB</b>",
            //    Password = "haha"
            //};
        }

        [BindProperty]
        public User CurrentUser { get; set; }
        

        public IActionResult OnPostBtnLogin_Click()
        {
            if (ModelState.IsValid)
            {
                if (CurrentUser.UserName == "admin" && CurrentUser.Password == "admin888")
                {
                    ShowNotify("成功登录！", MessageBoxIcon.Success);
                }
                else
                {
                    ShowNotify(String.Format("用户名（{0}）或密码（{1}）错误！",
                        CurrentUser.UserName,
                        CurrentUser.Password), MessageBoxIcon.Error);
                }
            }

            return UIHelper.Result();
        }

    }
}