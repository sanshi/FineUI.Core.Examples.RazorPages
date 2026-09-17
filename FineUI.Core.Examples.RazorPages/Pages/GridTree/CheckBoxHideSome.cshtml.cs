using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using Newtonsoft.Json.Linq;
using System.Text;

namespace FineUI.Core.Examples.RazorPages.Pages.GridTree
{
    public class CheckBoxHideSomeModel : BaseModel
    {
        public void OnGet()
        {

        }

        public IActionResult OnPostBtnGetCheckedValues_Click(JArray checkedRows)
        {
            var labResult = UIHelper.Label("labResult");

            if (checkedRows.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("复选框选中的值：");
                sb.Append("<ul>");

                foreach (JObject checkedNode in checkedRows)
                {
                    sb.AppendFormat("<li>{0}（{1}）</li>", checkedNode.Value<string>("text"), checkedNode.Value<string>("id"));
                }

                sb.Append("</ul>");

                labResult.Text(sb.ToString());
            }
            else
            {
                labResult.Text("没有复选框被选中");
            }


            return UIHelper.Result();
        }

    }
}