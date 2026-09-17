using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Toolbar
{
    public class MenuDynamicButtonModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostBtnDynamic_Click(int count)
        {
            ShowNotify("工具栏中的按钮数：" + count);

            return UIHelper.Result();
        }


    }
}