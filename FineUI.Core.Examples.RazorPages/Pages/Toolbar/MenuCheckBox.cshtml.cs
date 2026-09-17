using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Toolbar
{
    public class MenuCheckBoxModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostMenuLang_CheckedChanged(string checkedValue)
        {
            UIHelper.Label("labLangResult").Text("你选择的语言：" + checkedValue);

            return UIHelper.Result();
        }

        public IActionResult OnPostMenuSite_CheckedChanged(string checkedValue)
        {
            UIHelper.Label("labSiteResult").Text("你选择的站点：" + checkedValue);

            return UIHelper.Result();
        }

    }
}