using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.ThirdParty
{
    public class ColorPickerModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostBtnSubmit_Click(string dateValue, string textValue)
        {
            ShowNotify(String.Format("日期一：{0} 颜色值：{1}", dateValue, textValue));

            return UIHelper.Result();
        }

    }
}