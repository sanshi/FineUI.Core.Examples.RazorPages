using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Tree
{
    public class TreeNodeClickContextMenuModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostTree1_NodeClick(string nodeId, string nodeText)
        {
            UIHelper.Label("labResult").Text(String.Format("你点击了树节点：{0}（{1}）", nodeId, nodeText));

            return UIHelper.Result();
        }

    }
}