using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Other
{
    public class FieldLabelStyleModel : BaseModel
    {
        public void OnGet()
        {

        }

        public IActionResult OnPostBtnSwitchClass_Click(bool hasClassRed)
        {
            var tbxUserName = UIHelper.TextBox("tbxUserName");
            var tbxPassword = UIHelper.TextBox("tbxPassword");

            if (hasClassRed)
            {
                tbxUserName.RemoveCssClass("red");
                tbxPassword.RemoveCssClass("red");

                tbxUserName.AddCssClass("blue");
                tbxPassword.AddCssClass("blue");
            }
            else
            {
                tbxUserName.RemoveCssClass("blue");
                tbxPassword.RemoveCssClass("blue");

                tbxUserName.AddCssClass("red");
                tbxPassword.AddCssClass("red");
            }

            return UIHelper.Result();
        }

    }
}