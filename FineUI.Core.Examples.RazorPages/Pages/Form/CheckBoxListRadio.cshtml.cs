using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Form
{
    public class CheckBoxListRadioModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostCheckBoxList1_Change(string selected)
        {
            if (!String.IsNullOrEmpty(selected))
            {
                ShowNotify(String.Format("列表一的选中项：{0}", selected));
            }
            else
            {
                ShowNotify("列表一没有选中项！");
            }

            return UIHelper.Result();
        }

    }
}