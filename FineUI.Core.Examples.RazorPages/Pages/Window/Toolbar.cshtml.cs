using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Window
{
    public class ToolbarModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostBtnClose_Click()
        {
            UIHelper.Window("Window1").Hidden(true);

            return UIHelper.Result();
        }

        public IActionResult OnPostBtnChangeText_Click()
        {
            RegisterStartupScript(String.Format("$('#mylabel').html('{0}')", "这是修改后的值！" + DateTime.Now.ToLongTimeString()));
            
            return UIHelper.Result();
        }

        
    }
}