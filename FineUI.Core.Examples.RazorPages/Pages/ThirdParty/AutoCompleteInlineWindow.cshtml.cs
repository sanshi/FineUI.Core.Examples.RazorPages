using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.ThirdParty
{
    public class AutoCompleteInlineWindowModel : BaseModel
    {
        public void OnGet()
        {

        }


        

        public IActionResult OnPostButton1_Click(string TextBox1)
        {
            ShowNotify(String.Format("用户输入值：{0}", TextBox1));

            return UIHelper.Result();
        }

    }
}