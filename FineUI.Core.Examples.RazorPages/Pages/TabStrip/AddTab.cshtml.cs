using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.TabStrip
{
    public class AddTabModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostBtnAddTab3_Click()
        {
            UIHelper.TabStrip("TabStrip1").AddTab("dynamic_tab3", "https://deepseek.com/", "DeepSeek官网（服务端代码）", IconHelper.GetIconUrl(Icon.Application), true);

            return UIHelper.Result();
        }

        public IActionResult OnPostBtnAddTab4_Click()
        {
            UIHelper.TabStrip("TabStrip1").AddTab("dynamic_tab4", "https://asp.net/", "ASP.NET官网（服务端代码）", IconHelper.GetIconUrl(Icon.ApplicationAdd), true);

            return UIHelper.Result();
        }

        public IActionResult OnPostBtnRemoveTab3_Click()
        {
            UIHelper.TabStrip("TabStrip1").CloseTab("dynamic_tab3");

            return UIHelper.Result();
        }

        public IActionResult OnPostBtnRemoveTab4_Click()
        {
            UIHelper.TabStrip("TabStrip1").CloseTab("dynamic_tab4");

            return UIHelper.Result();
        }
    }
}