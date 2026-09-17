using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

namespace FineUI.Core.Examples.RazorPages.Pages.DatePicker
{
    public class DatePickerDisplayYearMinDateModel : BaseModel
    {
        public void OnGet()
        {
            ViewBag.DatePicker1SelectedDate = DateTime.Now;
            ViewBag.DatePicker1MinDate = DateTime.Now.AddYears(-5);
            ViewBag.DatePicker1MaxDate = DateTime.Now.AddYears(5);
        }


        
        public IActionResult OnPostBtnSubmit_Click(IFormCollection values)
        {
            var result = String.Format("开始年份：{0}  结束年份：{1}",
                values["DatePicker1"],
                values["DatePicker2"]);

            UIHelper.Label("labResult").Text(result);

            return UIHelper.Result();
        }

    }
}