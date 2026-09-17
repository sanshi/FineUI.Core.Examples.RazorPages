using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;

namespace FineUI.Core.Examples.RazorPages.Pages.GridOther
{
    public class DateOnlyModel : BaseModel
    {
        public void OnGet()
        {

        }



        public IActionResult OnPostButton1_Click(JArray selected)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<table class=\"result\"><tr><th>ID</th><th>Text</th><th>性别</th><th>专业</th><th>仅日期</th><th>仅时间</th></tr>");

            foreach (JArray item in selected)
            {
                sb.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td></tr>",
                    item[0], item[1],
                    Convert.ToInt32(item[2].ToString()) == 1 ? "男" : "女",
                    item[3], item[4], item[5]);
            }

            sb.Append("</table>");

            ShowNotify(new RawHtml(sb.ToString()), MessageBoxIcon.None);

            return UIHelper.Result();
        }


    }
}