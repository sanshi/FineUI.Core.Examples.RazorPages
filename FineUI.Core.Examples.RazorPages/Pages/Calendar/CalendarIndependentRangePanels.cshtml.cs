using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FineUI.Core.Examples.RazorPages.Pages.Calendar
{
    public class CalendarIndependentRangePanelsModel : BaseModel
    {
        public void OnGet()
        {
            ViewBag.Calendar1RangeStartDate = DateTime.Parse("2020-03-02");
            ViewBag.Calendar1RangeEndDate = DateTime.Parse("2026-08-18");

            ViewBag.Calendar2RangeStartDate = DateTime.Parse("2020-03-01");
            ViewBag.Calendar2RangeEndDate = DateTime.Parse("2026-08-01");

            ViewBag.Calendar3RangeStartDate = DateTime.Parse("2001-01-01");
            ViewBag.Calendar3RangeEndDate = DateTime.Parse("2026-01-01");
        }

        public IActionResult OnPostButton1_Click(string text1, string text2, string text3)
        {
            var result = String.Format("日期范围：{0}<br>月份范围：{1}<br>年份范围：{2}", text1, text2, text3);

            UIHelper.Label("labResult").Text(result);

            return UIHelper.Result();
        }
    }
}
