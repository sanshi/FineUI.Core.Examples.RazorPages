using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Form
{
    public class ImageModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostButton1_Click(int imageWidth)
        {
            var Image3 = UIHelper.Image("Image3");

            if (imageWidth == 32)
            {
                Image3.ImageWidth(64);
                Image3.ImageHeight(64);
            }
            else
            {
                Image3.ImageWidth(32);
                Image3.ImageHeight(32);
            }

            return UIHelper.Result();
        }

    }
}