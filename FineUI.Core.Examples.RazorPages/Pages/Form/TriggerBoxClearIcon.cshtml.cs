using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Form
{
    public class TriggerBoxClearIconModel : BaseModel
    {
        public void OnGet()
        {

        }


        

        public IActionResult OnPostBtnSubmit_Click(string box1Value)
        {
            Alert.Show("文本框的输入值：" + box1Value);

            return UIHelper.Result();
        }

    }
}