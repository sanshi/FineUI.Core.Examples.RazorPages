using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Grid
{
    public class CheckAllModel : PageBase
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostButton2_Click()
        {
            UIHelper.Grid("Grid1").SelectedRowIDArray("102", "106", "108");

            return UIHelper.Result();
        }

        public IActionResult OnPostButton1_Click(JArray selected)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("共选中了 {0} 行<br />", selected.Count);
            sb.Append("<table class=\"result\"><tr><th>ID</th><th>Text</th><th>性别</th><th>专业</th></tr>");

            foreach (JArray item in selected)
            {
                sb.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td></tr>",
                    item[0], item[1], 
                    Convert.ToInt32(item[2].ToString()) == 1 ? "男" : "女",
                    item[3]);
            }

            sb.Append("</table>");

            ShowNotify(new RawHtml(sb.ToString()), MessageBoxIcon.None);

            return UIHelper.Result();
        }


    }
}
