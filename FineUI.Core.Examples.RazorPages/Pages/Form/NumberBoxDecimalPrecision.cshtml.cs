using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Form
{
    public class NumberBoxDecimalPrecisionModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostBtnSubmit_Click(string number)
        {
            ShowNotify("数字输入框的值：" + number);

            return UIHelper.Result();
        }
        

        public IActionResult OnPostButton1_Click()
        {
            var NumberBox1 = UIHelper.NumberBox("NumberBox1");

            NumberBox1.DecimalPrecision(1);
            NumberBox1.Increment(0.1);
            
            return UIHelper.Result();
        }

        public IActionResult OnPostButton2_Click()
        {
            var NumberBox1 = UIHelper.NumberBox("NumberBox1");

            NumberBox1.DecimalPrecision(2);
            NumberBox1.Increment(0.01);

            return UIHelper.Result();
        }

        public IActionResult OnPostButton3_Click()
        {
            var NumberBox1 = UIHelper.NumberBox("NumberBox1");

            NumberBox1.DecimalPrecision(3);
            NumberBox1.Increment(0.001);

            return UIHelper.Result();
        }

    }
}