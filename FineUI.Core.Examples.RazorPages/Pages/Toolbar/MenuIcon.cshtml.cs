using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Toolbar
{
    public class MenuIconModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostButton1_Click(string icon)
        {
            var MenuHyperLink1 = UIHelper.MenuHyperLink("MenuHyperLink1");

            if (icon.EndsWith("accept.png"))
            {
                MenuHyperLink1.Icon(Icon.None);
            }
            else
            {
                MenuHyperLink1.Icon(Icon.Accept);
            }

            return UIHelper.Result();
        }


        public IActionResult OnPostButton2_Click(string icon)
        {
            var MenuHyperLink2 = UIHelper.MenuHyperLink("MenuHyperLink2");

            if (icon.EndsWith("accept.png"))
            {
                MenuHyperLink2.Icon(Icon.Application);
            }
            else
            {
                MenuHyperLink2.Icon(Icon.Accept);
            }

            return UIHelper.Result();
        }

    }
}