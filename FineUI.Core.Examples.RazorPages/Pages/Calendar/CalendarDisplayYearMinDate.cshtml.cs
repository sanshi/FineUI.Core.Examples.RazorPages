using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace FineUI.Core.Examples.RazorPages.Pages.Calendar
{
    public class CalendarDisplayYearMinDateModel : BaseModel
    {
        public void OnGet()
        {
            ViewBag.Calendar1DateFormatString = Calendar1DateFormatString;
            ViewBag.Calendar1Text = DateTime.Now.Year.ToString();

            ViewBag.Calendar1MinDate = DateTime.Now.AddYears(-5);
            ViewBag.Calendar1MaxDate = DateTime.Now.AddYears(5);


            ViewBag.Button1Text = String.Format("选中{0}", DateTime.Now.AddYears(2).Year);


        }


        public static readonly string Calendar1DateFormatString = "yyyy";

        

        public IActionResult OnPostCalendar1_DateSelect(string text)
        {
            UpdateResult(text);
            
            return UIHelper.Result();
        }

        public IActionResult OnPostButton1_Click()
        {
            var text = DateTime.Now.AddYears(2).Year.ToString();
            UIHelper.Calendar("Calendar1").Text(text);

            UpdateResult(text);

            return UIHelper.Result();
        }


        private void UpdateResult(string text)
        {
            UIHelper.Label("labResult").Text(String.Format("选择的年份：{0}", text));
        }
    }
}