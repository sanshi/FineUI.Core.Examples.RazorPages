using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace FineUI.Core.Examples.RazorPages.Pages.Calendar
{
    public class CalendarYearRangeModel : BaseModel
    {
        private DateTime startDate = DateTime.Now.AddYears(2);
        private DateTime endDate = DateTime.Now.AddYears(10);

        private string GetRangeText()
        {
            return String.Format("{0} - {1}", startDate.ToString(Calendar1DateFormatString), endDate.ToString(Calendar1DateFormatString));
        }


        public static readonly string Calendar1DateFormatString = "yyyy";

        public void OnGet()
        {
            ViewBag.Calendar1DateFormatString = Calendar1DateFormatString;

            ViewBag.Calendar1RangeStartDate = DateTime.Now.AddYears(0);
            ViewBag.Calendar1RangeEndDate = DateTime.Now.AddYears(5);

            ViewBag.Calendar1MinDate = DateTime.Now.AddYears(-5);
            ViewBag.Calendar1MaxDate = DateTime.Now.AddYears(15);

            ViewBag.Button1Text = String.Format("选中范围：{0}", GetRangeText());

        }



        public IActionResult OnPostCalendar1_DateSelect(string text)
        {
            UpdateResult(text);
            
            return UIHelper.Result();
        }

        public IActionResult OnPostButton1_Click()
        {
            UIHelper.Calendar("Calendar1").RangeStartEndDate(startDate, endDate, Calendar1DateFormatString);

            UpdateResult(GetRangeText());

            return UIHelper.Result();
        }


        private void UpdateResult(string text)
        {
            UIHelper.Label("labResult").Text(String.Format("年份范围：{0}", text));
        }
    }
}