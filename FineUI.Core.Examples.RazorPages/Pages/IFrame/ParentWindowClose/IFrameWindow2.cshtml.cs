using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.IFrame.ParentWindowClose
{
    public class IFrameWindow2Model : BaseModel
    {
        public void OnGet()
        {

        }


        public IActionResult OnPostIFrameWindow2_Button1_Click()
        {
            ActiveWindow.HidePostBack();

            return UIHelper.Result();
        }
    }
}