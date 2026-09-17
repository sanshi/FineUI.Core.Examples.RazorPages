using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.IFrame.ParentWindowClose
{
    public class IFrameWindow1Model : BaseModel
    {
        public void OnGet()
        {

        }


        public IActionResult OnPostIFrameWindow1_Window1_Close()
        {
            // IFrameWindow1 -> labResult
            UIHelper.Label("labResult").Text(DateTime.Now.ToLongTimeString());

            // 调用父页面定义的函数 updateLabelResult
            RegisterStartupScript("parent.updateLabelResult();");

            return UIHelper.Result();
        }

    }
}