using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.TabStrip
{
    public class AddTabRemoveOnCloseModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostBtnAddTab3_Click()
        {
            UIHelper.TabStrip("TabStrip1").AddTab(new TabOptions()
            {
                ID = "dynamic_tab3",
                IFrameUrl = "https://deepseek.com/",
                Title = "DeepSeek官网（服务端代码）",
                IconUrl = IconHelper.GetIconUrl(Icon.Application),
                EnableClose = true,
                RemoveOnClose = true
            });

            return UIHelper.Result();
        }

        public IActionResult OnPostBtnAddTab4_Click()
        {
            UIHelper.TabStrip("TabStrip1").AddTab(new TabOptions()
            {
                ID = "dynamic_tab4",
                IFrameUrl = "https://asp.net/",
                Title = "ASP.NET官网（服务端代码）",
                IconUrl = IconHelper.GetIconUrl(Icon.ApplicationAdd),
                EnableClose = true,
                RemoveOnClose = true
            });

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