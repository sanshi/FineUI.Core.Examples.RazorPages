using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;

namespace FineUI.Core.Examples.RazorPages.Pages.MultiLang
{
    public partial class TreeCheckBoxModel : BaseMultilangModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostBtnGetCheckedValues_Click(JArray checkedNodes)
        {
            var labResult = UIHelper.Label("labResult");

            if (checkedNodes.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(_R("复选框选中的节点："));
                sb.Append("<ul>");

                foreach (JObject checkedNode in checkedNodes)
                {
                    sb.Append(_R("<li>{0}（{1}）</li>", checkedNode.Value<string>("text"), checkedNode.Value<string>("id")));
                }

                sb.Append("</ul>");
                
                labResult.Text(sb.ToString());
            }
            else
            {
                labResult.Text(_R("没有复选框选中的节点"));
            }


            return UIHelper.Result();
        }


        
    }
}