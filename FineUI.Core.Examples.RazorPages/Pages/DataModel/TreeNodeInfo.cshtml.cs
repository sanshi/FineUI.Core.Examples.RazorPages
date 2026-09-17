using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
using FineUI.Core.Examples.RazorPages.Pages.DataModel.Models;

namespace FineUI.Core.Examples.RazorPages.Pages.DataModel
{
    public class TreeNodeInfoModel : BaseModel
    {
        public void OnGet()
        {

        }

        [BindProperty]
        public IList<TreeNodeInfo> CheckedNodes { get; set; }



        public IActionResult OnPostBtnGetCheckedValues_Click()
        {
            var labResult = UIHelper.Label("labResult");

            if (CheckedNodes != null && CheckedNodes.Count() > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("复选框选中的节点：");
                sb.Append("<ul>");

                foreach (TreeNodeInfo checkedNode in CheckedNodes)
                {
                    sb.AppendFormat("<li>{0}（{1}）</li>", checkedNode.NodeText, checkedNode.NodeId);
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