using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Panel
{
    public class GroupModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostButton2_Click(bool collapsed)
        {
            UIHelper.GroupPanel("GroupPanel2").Collapsed(!collapsed);

            return UIHelper.Result();
        }

    }
}