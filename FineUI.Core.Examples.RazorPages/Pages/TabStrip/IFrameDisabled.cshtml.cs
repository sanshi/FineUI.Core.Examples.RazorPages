using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

namespace FineUI.Core.Examples.RazorPages.Pages.TabStrip
{
    public class IFrameDisabledModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        //// GET: TabStrip/IFrameDisabled/Tab1
        //public IActionResult Tab1()
        //{
        //    return View();
        //}

        public IActionResult OnPostBtnSubmit_Click(IFormCollection values)
        {
            

            ShowNotify(values);

            return UIHelper.Result();
        }

    }
}