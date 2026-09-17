using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

namespace FineUI.Core.Examples.RazorPages.Pages.Form
{
    public class NumberBoxRateModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostButton1_Click(int currentNum)
        {
            currentNum++;
            if (currentNum > 5)
            {
                currentNum = 0;
            }

            UIHelper.NumberBox("NumberBox12").Text(currentNum.ToString());

            return UIHelper.Result();
        }

    }
}