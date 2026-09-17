using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.TabStrip
{
    public class TabIndexChangedModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostButton3_Click(int activeIndex)
        {
            int nextIndex = activeIndex + 1;

            if (nextIndex >= 3)
            {
                nextIndex = 0;
            }

            UIHelper.TabStrip("TabStrip1").ActiveTabIndex(nextIndex);

            return UIHelper.Result();
        }


        public IActionResult OnPostTabStrip1_TabIndexChanged(int activeIndex)
        {
            if (activeIndex == 0)
            {
                UIHelper.Label("Label1").Text("标签回发时间：" + DateTime.Now.ToLongTimeString());
            }
            else if (activeIndex == 1)
            {
                UIHelper.Label("Label2").Text("标签回发时间：" + DateTime.Now.ToLongTimeString());
            }
            else if (activeIndex == 2)
            {
                UIHelper.Label("Label3").Text("标签回发时间：" + DateTime.Now.ToLongTimeString());
            }

            return UIHelper.Result();
        }
        
    }
}