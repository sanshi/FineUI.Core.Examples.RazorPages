using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

namespace FineUI.Core.Examples.RazorPages.Pages.DatePicker
{
    public class DatePickerMonthRangeModel : BaseModel
    {
        public void OnGet()
        {
            ViewBag.DatePicker1RangeStartDate = DateTime.Now.AddMonths(0);
            ViewBag.DatePicker1RangeEndDate = DateTime.Now.AddMonths(5);

            ViewBag.DatePicker1MinDate = DateTime.Now.AddMonths(-5);
            ViewBag.DatePicker1MaxDate = DateTime.Now.AddMonths(15);
        }


        
        public IActionResult OnPostBtnSubmit_Click(IFormCollection values)
        {
            var result = String.Format("月份范围：{0}", values["DatePicker1"]);

            UIHelper.Label("labResult").Text(result);

            return UIHelper.Result();
        }

    }
}