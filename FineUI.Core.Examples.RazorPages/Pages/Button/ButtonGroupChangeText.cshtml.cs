using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Button
{
    public class ButtonGroupChangeTextModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostBtnChangeButtonText_Click(string text)
        {
            UIHelper.Button("Button4").Text(text.Length == 3 ? "按钮四（" + DateTime.Now.ToString() + "）" : "按钮四");

            return UIHelper.Result();
        }

        public IActionResult OnPostBtnShowHideButton_Click(bool hidden)
        {
            UIHelper.Button("Button4").Hidden(!hidden);

            return UIHelper.Result();
        }


        public IActionResult OnPostBtnChangeButtonText2_Click(string text)
        {
            UIHelper.Button("Button8").Text(text.Length == 3 ? "按钮八（" + DateTime.Now.ToString() + "）" : "按钮八");

            return UIHelper.Result();
        }

        public IActionResult OnPostBtnShowHideButton2_Click(bool hidden)
        {
            UIHelper.Button("Button8").Hidden(!hidden);

            return UIHelper.Result();
        }

    }
}