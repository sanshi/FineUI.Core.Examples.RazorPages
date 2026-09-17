using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Other
{
    public class ClientValidateModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostBtnRegister_Click(IFormCollection values)
        {
            Alert.Show("表单验证通过！");

            return UIHelper.Result();
        }

    }
}