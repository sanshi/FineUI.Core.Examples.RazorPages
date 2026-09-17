using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Tree
{
    public class TreeNodeExpandModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostTree1_NodeExpand(JObject nodeInfo)
        {
            UIHelper.Label("labResult").Text(String.Format("展开节点：{0}（{1}）", nodeInfo.Value<string>("id"), nodeInfo.Value<string>("text")));

            return UIHelper.Result();
        }

        public IActionResult OnPostTree1_NodeCollapse(JObject nodeInfo)
        {
            UIHelper.Label("labResult").Text(String.Format("折叠节点：{0}（{1}）", nodeInfo.Value<string>("id"), nodeInfo.Value<string>("text")));

            return UIHelper.Result();
        }

    }
}