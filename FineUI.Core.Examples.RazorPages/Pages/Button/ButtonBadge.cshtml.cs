using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Button
{
    public class ButtonBadgeModel : BaseModel
    {
        public void OnGet()
        {

        }


        

        public IActionResult OnPostBtnCustomIcon_Click(string iconUrl)
        {
            var btnCustomIcon = UIHelper.Button("btnCustomIcon");

            if (iconUrl.EndsWith("1.png"))
            {
                btnCustomIcon.IconUrl("~/res/images/16/8.png");
            }
            else
            {
                btnCustomIcon.IconUrl("~/res/images/16/1.png");
            }

            return UIHelper.Result();
        }

       
        public ActionResult OnPostBtnChangeBadge_Click(string badgeNumber)
        {
            var btnBadgeNumber = UIHelper.Button("btnBadgeNumber");

            btnBadgeNumber.Badge(true, (Convert.ToInt32(badgeNumber) + 1).ToString());

            return UIHelper.Result();
        }

    }
}