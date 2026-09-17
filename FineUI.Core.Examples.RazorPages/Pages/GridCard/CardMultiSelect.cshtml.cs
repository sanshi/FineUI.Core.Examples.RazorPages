using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Text;

namespace FineUI.Core.Examples.RazorPages.Pages.GridCard
{
    public class CardMultiSelectModel : BaseModel
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
