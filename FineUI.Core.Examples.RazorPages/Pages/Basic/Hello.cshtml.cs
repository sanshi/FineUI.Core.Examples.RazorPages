using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Basic
{
    public class HelloModel : BaseModel
    {
        public void OnGet()
        {
            
        }

        public IActionResult OnPostBtnHello_Click()
        {
            Alert.Show("你好 FineUI！", MessageBoxIcon.Warning);

            return UIHelper.Result();
        }

        
        public IActionResult OnPostBtnHello2_Click()
        {
            Alert.ShowInTop("你好 FineUI！", MessageBoxIcon.Information);

            return UIHelper.Result();
        }
    }
}