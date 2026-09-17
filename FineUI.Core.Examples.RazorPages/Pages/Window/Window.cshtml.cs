using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Window
{
    public class WindowModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostWindow1_Close()
        {
            Alert.Show("触发了窗体的关闭事件！");

            return UIHelper.Result();
        }

        public IActionResult OnPostBtnShowInServer_Click()
        {
            UIHelper.Window("Window1").Show();

            return UIHelper.Result();
        }


        public IActionResult OnPostBtnHideInServer_Click()
        {
            UIHelper.Window("Window1").Hide();

            return UIHelper.Result();
        }

    }
}