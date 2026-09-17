using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FineUI.Core.Examples.RazorPages.Pages.DatePicker
{
    public class DatePickerTimeStackModel : BaseModel
    {
        public void OnGet()
        {

        }



        public IActionResult OnPostBtnSubmit_Click(IFormCollection values)
        {
            var result = String.Format("开始日期：{0}  结束日期：{1}",
                values["DatePicker1"],
                values["DatePicker2"]);

            UIHelper.Label("labResult").Text(result);

            return UIHelper.Result();
        }

    }
}
