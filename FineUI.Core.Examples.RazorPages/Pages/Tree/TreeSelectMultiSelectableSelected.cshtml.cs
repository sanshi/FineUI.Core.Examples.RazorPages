using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Tree
{
    public class TreeSelectMultiSelectableSelectedModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostBtnGetSelectedValues_Click(JArray selectedNodes)
        {
            var labResult = UIHelper.Label("labResult");

            if (selectedNodes.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("选中的节点：");
                sb.Append("<ul>");

                foreach (JObject node in selectedNodes)
                {
                    sb.AppendFormat("<li>{0}（{1}）</li>", node.Value<string>("text"), node.Value<string>("id"));
                }

                sb.Append("</ul>");

                labResult.Text(sb.ToString());
            }
            else
            {
                labResult.Text("没有选中的节点");
            }


            return UIHelper.Result();
        }

        public IActionResult OnPostBtnSelectOthers_Click(string selectedNodes)
        {
            UIHelper.Tree("Tree1").SelectedNodeIDArray(true, "hefei", "huangshan");

            return UIHelper.Result();
        }

    }
}