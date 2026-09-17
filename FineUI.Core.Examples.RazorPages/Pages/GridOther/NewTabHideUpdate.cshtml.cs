using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using Newtonsoft.Json.Linq;


namespace FineUI.Core.Examples.RazorPages.Pages.GridOther
{
    public class NewTabHideUpdateModel : BaseModel
    {
        public void OnGet()
        {

        }


        

        public IActionResult OnPostCustomEvent(string param)
        {
            Alert.Show(String.Format("来自子页面的参数：{0}", param));

            return UIHelper.Result();
        }

    }
}