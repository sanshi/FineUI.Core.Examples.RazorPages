using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

namespace FineUI.Core.Examples.RazorPages.Pages.TabStrip
{
    public class IFrameReLoadFirstModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        //// GET: TabStrip/IFrameReLoadFirst/EmptyPage
        //public IActionResult EmptyPage()
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