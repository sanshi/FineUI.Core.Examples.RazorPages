using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Panel
{
    public class DisabledModel : BaseModel
    {
        public void OnGet()
        {
            ViewBag.Panel2Content = "可以在此放置<a href=\"http://www.w3schools.com/html/\" target=\"_blank\">HTML</a>标签。";
        }


        
        public IActionResult OnPostButton2_Click(bool disabled)
        {
            UIHelper.Panel("Panel1").Disabled(!disabled);

            return UIHelper.Result();
        }

    }
}