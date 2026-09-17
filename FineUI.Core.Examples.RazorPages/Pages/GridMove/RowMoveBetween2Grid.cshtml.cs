using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using Newtonsoft.Json.Linq;
using System.Text;


namespace FineUI.Core.Examples.RazorPages.Pages.GridMove
{
    public class RowMoveBetween2GridModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostBtnCheckSelected_Click(JArray columnNames)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<ul>");
            foreach (JObject item in columnNames)
            {
                sb.AppendFormat("<li>ID:{0} Name:{1}</li>", item.Value<string>("id"), item.Value<string>("name"));
            }
            sb.Append("</ul>");

            ShowNotify(new RawHtml("已选择列表：" + sb.ToString()), MessageBoxIcon.None);

            return UIHelper.Result();
        }

    }
}