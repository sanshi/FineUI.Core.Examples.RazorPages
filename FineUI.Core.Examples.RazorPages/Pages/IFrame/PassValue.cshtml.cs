using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.IFrame
{
    public class PassValueModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostButton1_Click(string province)
        {
            var window1 = UIHelper.Window("Window1");
            string openUrl = String.Format("{0}?selected={1}", Url.Content("~/IFrame/PassValue/IFrameWindow"), HttpUtility.UrlEncode(province));

            window1.SaveStateControlIDs("tbxProvince");
            window1.Show(openUrl);

            return UIHelper.Result();
        }


        //public IActionResult OnPostWindow1_Close()
        //{
        //    ShowNotify("触发了 Window1 的关闭事件！");

        //    return UIHelper.Result();
        //}



    }
}