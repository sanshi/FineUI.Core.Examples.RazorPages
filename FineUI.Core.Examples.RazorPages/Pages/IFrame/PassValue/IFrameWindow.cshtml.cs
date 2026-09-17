using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.IFrame.PassValue
{
    public class IFrameWindowModel : BaseModel
    {
        public void OnGet()
        {

        }


        public IActionResult OnPostDdlSheng_SelectedIndexChanged(string province)
        {
            RegisterStartupScript(ActiveWindow.GetWriteBackValueReference(province) + ActiveWindow.GetHideReference());

            return UIHelper.Result();
        }
    }
}