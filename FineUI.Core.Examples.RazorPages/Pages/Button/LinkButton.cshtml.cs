using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Button
{
    public class LinkButtonModel : BaseModel
    {
        public IActionResult OnPostLinkButton3_Click()
        {
            ShowNotify("这是服务器端事件");

            return UIHelper.Result();
        }

        public IActionResult OnPostBtnChangeEnable_Click(bool enabled)
        {
            UIHelper.LinkButton("LinkButton1").Enabled(!enabled);
            
            return UIHelper.Result();
        }
        
    }
}