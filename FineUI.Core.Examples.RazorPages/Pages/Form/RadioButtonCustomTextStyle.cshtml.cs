using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Form
{
    public class RadioButtonCustomTextStyleModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostBtnSelectSingleRadio_Click(bool isChecked)
        {
            UIHelper.RadioButton("rbtnSingleRadio").Checked(!isChecked);

            return UIHelper.Result();
        }

        public IActionResult OnPostBtnSelectSecondRadio_Click(string checkedRadio)
        {
            String[] radios = new String[] { "rbtnFirst", "rbtnSecond", "rbtnThird" };

            for (int i = 0; i < radios.Length; i++)
            {
                if (radios[i] == checkedRadio)
                {
                    int next = i + 1;
                    if (next >= radios.Length)
                    {
                        next = 0;
                    }

                    UIHelper.RadioButton(radios[next]).Checked(true);

                    break;
                }
            }

            return UIHelper.Result();
        }


        public IActionResult OnPostRbtnAuto_CheckedChanged(string checkedRadio)
        {
            ShowNotify("单选框选中项：" + checkedRadio);

            return UIHelper.Result();
        }

        
    }
}