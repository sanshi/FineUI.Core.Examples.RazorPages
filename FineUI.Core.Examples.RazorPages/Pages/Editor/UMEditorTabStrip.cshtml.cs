using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Editor
{
    public class UMEditorTabStripModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostButton1_Click(string text1, string text2)
        {
            ShowNotify(new RawHtml("编辑器一：{0}<br/>编辑器二：{1}", HttpUtility.HtmlEncode(text1), HttpUtility.HtmlEncode(text2)));

            return UIHelper.Result();
        }

    }
}