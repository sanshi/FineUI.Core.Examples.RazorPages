using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Form
{
    public class TriggerBoxModel : BaseModel
    {
        public void OnGet()
        {

        }


        

        public IActionResult OnPostBtnCloseWindow_Click()
        {
            UIHelper.Window("Window1").Hide();
            UIHelper.TriggerBox("TriggerBox1").Text("弹出窗口被关闭了");

            return UIHelper.Result();
        }

    }
}