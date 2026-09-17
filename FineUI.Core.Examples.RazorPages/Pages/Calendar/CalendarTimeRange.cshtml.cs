using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace FineUI.Core.Examples.RazorPages.Pages.Calendar
{
    public class CalendarTimeRangeModel : BaseModel
    {
        
        public static readonly string Calendar1DateFormatString = "HH:mm:ss";

        public void OnGet()
        {
            ViewBag.Calendar1DateFormatString = Calendar1DateFormatString;

            ViewBag.Calendar1Text = "14:30:00 - 16:30:00";

            ViewBag.Button1Text = String.Format("选中范围：{0} - {1}", "08:50:00", "11:50:00");

        }



        public IActionResult OnPostCalendar1_DateSelect(string text)
        {
            UpdateResult(text);
            
            return UIHelper.Result();
        }

        public IActionResult OnPostButton1_Click()
        {
            var text = "08:50:00 - 11:50:00";

            UIHelper.Calendar("Calendar1").Text(text);

            UpdateResult(text);

            return UIHelper.Result();
        }


        private void UpdateResult(string text)
        {
            UIHelper.Label("labResult").Text(String.Format("时间范围：{0}", text));
        }
    }
}