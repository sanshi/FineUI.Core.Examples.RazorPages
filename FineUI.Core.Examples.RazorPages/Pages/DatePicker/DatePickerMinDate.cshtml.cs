using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.DatePicker
{
    public class DatePickerMinDateModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostBtnSubmit_Click(string date)
        {
            UIHelper.Label("labResult").Text(String.Format("选择的日期：{0}", date));

            return UIHelper.Result();
        }

    }
}