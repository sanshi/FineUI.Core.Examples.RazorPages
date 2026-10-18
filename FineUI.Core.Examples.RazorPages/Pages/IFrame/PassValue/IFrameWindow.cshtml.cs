using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.IFrame.PassValue
{
    public class IFrameWindowModel : PageBase
    {
        public void OnGet()
        {

        }


        public IActionResult OnPostDdlSheng_SelectedIndexChanged(string province)
        {
            ActiveWindow.WriteBackValue(ProvinceCityCountyData.ProvinceName(province));
            ActiveWindow.Hide();

            return UIHelper.Result();
        }
    }
}