
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Calendar
{
    public class CalendarMinDateModel : BaseModel
    {
        public void OnGet()
        {
            ViewBag.Calendar1MinDate = DateTime.Now;
            ViewBag.Calendar1MaxDate = DateTime.Now.AddDays(20);

            ViewBag.Calendar1DateFormatString = Calendar1DateFormatString;
            ViewBag.Calendar1SelectedDate = DateTime.Now.AddDays(10);
            ViewBag.Button1Text = String.Format("选中{0}", DateTime.Now.AddDays(2).ToString(Calendar1DateFormatString));


        }


        public static readonly string Calendar1DateFormatString = "yyyy/MM/dd";

        

        public IActionResult OnPostCalendar1_DateSelect(string selectedDate)
        {
            UpdateResult(DateTime.Parse(selectedDate));

            return UIHelper.Result();
        }

        public IActionResult OnPostButton1_Click()
        {
            var selectedDate = DateTime.Now.AddDays(2);
            UIHelper.Calendar("Calendar1").SelectedDate(selectedDate);

            UpdateResult(selectedDate);

            return UIHelper.Result();
        }


        private void UpdateResult(DateTime date)
        {
            UIHelper.Label("labResult").Text(String.Format("选择的日期：{0}", date.ToString(Calendar1DateFormatString)));
        }
    }
}