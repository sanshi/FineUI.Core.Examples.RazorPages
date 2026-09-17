using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Calendar
{
    public class CalendarDisplayYearModel : BaseModel
    {
        public void OnGet()
        {
            ViewBag.Calendar1DateFormatString = Calendar1DateFormatString;
            ViewBag.Calendar1Text = DateTime.Now.Year.ToString();
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