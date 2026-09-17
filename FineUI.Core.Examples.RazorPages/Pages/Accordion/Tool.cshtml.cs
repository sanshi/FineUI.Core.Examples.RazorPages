using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Accordion
{
    public class ToolModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostButton1_Click(int activeIndex)
        {
            if (activeIndex == -1)
            {
                ShowNotify(String.Format("当前没有面板处于展开状态！"));
            }
            else
            {
                ShowNotify(String.Format("当前展开的是第 {0} 个面板", activeIndex + 1));
            }


            return UIHelper.Result();
        }

        public IActionResult OnPostButton2_Click(int activeIndex)
        {
            int nextIndex = activeIndex + 1;

            if (nextIndex >= 3)
            {
                nextIndex = 0;
            }

            UIHelper.Accordion("Accordion1").ActivePaneIndex(nextIndex);

            return UIHelper.Result();
        }

    }
}