using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

namespace FineUI.Core.Examples.RazorPages.Pages.DatePicker
{
    public class DatePickerDayRangeModel : BaseModel
    {
        public void OnGet()
        {
            ViewBag.DatePicker1RangeStartDate = DateTime.Parse("2014-07-30");
            ViewBag.DatePicker1RangeEndDate = DateTime.Parse("2014-08-08");
        }


        
        public IActionResult OnPostBtnSubmit_Click(IFormCollection values)
        {
            var result = String.Format("日期范围：{0}", values["DatePicker1"]);

            UIHelper.Label("labResult").Text(result);

            return UIHelper.Result();
        }

    }
}