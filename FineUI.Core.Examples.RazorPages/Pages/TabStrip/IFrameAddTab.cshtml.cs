using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.TabStrip
{
    public class IFrameAddTabModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostButton1_Click()
        {
            UIHelper.TabStrip("TabStrip1").AddTab("tab1_iframe", "https://deepseek.com/", "DeepSeek官网", true);

            return UIHelper.Result();
        }

        public IActionResult OnPostButton2_Click()
        {
            UIHelper.TabStrip("TabStrip1").AddTab("tab1_iframe", "https://asp.net/", "ASP.NET官网", true);

            return UIHelper.Result();
        }

        public IActionResult OnPostButton3_Click()
        {
            UIHelper.TabStrip("TabStrip1").AddTab("tab2_iframe", "https://fineui.com/", "FineUI官网", true);

            return UIHelper.Result();
        }

    }
}