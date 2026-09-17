using Microsoft.AspNetCore.Mvc;
using System;

namespace FineUI.Core.Examples.RazorPages.Pages.Calendar
{
    public class CalendarTimeNoInitialValueModel : BaseModel
    {
        public static readonly string Calendar1DateFormatString = "yyyy/MM/dd HH:mm:ss";

        public void OnGet()
        {
            ViewBag.Calendar1DateFormatString = Calendar1DateFormatString;
            //ViewBag.Calendar1SelectedDate = DateTime.Now.AddDays(10);

            DateTime newDate = DateTime.Now.AddDays(2);
            newDate = new DateTime(newDate.Year, newDate.Month, newDate.Day, 0, 0, 0);
            ViewBag.Button1Text = String.Format("选中{0}", newDate.ToString(Calendar1DateFormatString));
        }


        public IActionResult OnPostCalendar1_DateSelect(string selectedDate)
        {
            UpdateResult(DateTime.Parse(selectedDate));

            return UIHelper.Result();
        }

        public IActionResult OnPostButton1_Click()
        {
            var newDate = DateTime.Now.AddDays(2);
            newDate = new DateTime(newDate.Year, newDate.Month, newDate.Day, 0, 0, 0);
            UIHelper.Calendar("Calendar1").SelectedDate(newDate);

            UpdateResult(newDate);

            return UIHelper.Result();
        }


        private void UpdateResult(DateTime date)
        {
            UIHelper.Label("labResult").Text(String.Format("选择的日期：{0}", date.ToString(Calendar1DateFormatString)));
        }
    }
}
