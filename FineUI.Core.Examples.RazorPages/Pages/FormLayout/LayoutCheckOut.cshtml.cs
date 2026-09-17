using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.FormLayout
{
    public class LayoutCheckOutModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostCbxSameAsContactAddress_CheckedChanged(bool isChecked)
        {
            UIHelper.TextBox("tbxBillingAddress").Enabled(!isChecked);
            UIHelper.TextBox("tbxBillingProvince").Enabled(!isChecked);
            UIHelper.TextBox("tbxBillingCity").Enabled(!isChecked);
            UIHelper.TextBox("tbxBillingPostCode").Enabled(!isChecked);

            return UIHelper.Result();
        }

    }
}