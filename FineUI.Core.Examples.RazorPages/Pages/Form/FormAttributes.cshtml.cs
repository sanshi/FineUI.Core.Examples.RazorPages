using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using Newtonsoft.Json.Linq;


namespace FineUI.Core.Examples.RazorPages.Pages.Form
{
    public class FormAttributesModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostBtnChangeTip1_Click()
        {
            UIHelper.Label("Label1").ToolTip("改变后的提示信息（ToolTip）");

            return UIHelper.Result();
        }

        public IActionResult OnPostBtnChangeTip2_Click()
        {
            UIHelper.Label("Label2").Attribute("data-qtip", "改变后的提示信息（Attributes）");

            return UIHelper.Result();
        }

    }
}