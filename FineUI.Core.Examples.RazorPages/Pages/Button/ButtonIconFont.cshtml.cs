using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Button
{
    public class ButtonIconFontModel : BaseModel
    {
        public void OnGet()
        {

        }
        
        public IActionResult OnPostBtnCustomIconFont_Click(string iconFont)
        {
            var btnCustomIconFont = UIHelper.Button("btnCustomIconFont");

            if (iconFont == "f-iconfont-volume-up")
            {
                btnCustomIconFont.IconFont(IconFont._VolumeDown);
            }
            else if (iconFont == "f-iconfont-volume-down")
            {
                btnCustomIconFont.IconFont(IconFont._VolumeOff);
            }
            else
            {
                btnCustomIconFont.IconFont(IconFont._VolumeUp);
            }

            return UIHelper.Result();
        }
    }
}