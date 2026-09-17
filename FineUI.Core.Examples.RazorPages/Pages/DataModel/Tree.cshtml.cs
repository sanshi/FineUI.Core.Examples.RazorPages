using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.DataModel
{
    public class TreeModel : BaseModel
    {
        public void OnGet()
        {

        }


        [BindProperty]
        public JArray CheckedNodes { get; set; }


        public IActionResult OnPostBtnGetCheckedValues_Click()
        {
            var labResult = UIHelper.Label("labResult");

            if (CheckedNodes.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("复选框选中的节点：");
                sb.Append("<ul>");

                foreach (JObject checkedNode in CheckedNodes)
                {
                    sb.AppendFormat("<li>{0}（{1}）</li>", checkedNode.Value<string>("NodeText"), checkedNode.Value<string>("NodeId"));
                }

                sb.Append("</ul>");

                labResult.Text(sb.ToString());
            }
            else
            {
                labResult.Text("没有复选框选中的节点");
            }


            return UIHelper.Result();
        }
    }
}