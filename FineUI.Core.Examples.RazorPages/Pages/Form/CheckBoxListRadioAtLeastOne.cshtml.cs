using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Form
{
    public class CheckBoxListRadioAtLeastOneModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostCheckBoxList1_Change(string selected)
        {
            ShowNotify(String.Format("列表一的选中项：{0}", selected));

            return UIHelper.Result();
        }

    }
}