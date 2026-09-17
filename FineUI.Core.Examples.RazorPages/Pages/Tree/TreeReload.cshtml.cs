using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Tree
{
    public class TreeReloadModel : BaseModel
    {
        public void OnGet()
        {

        }


        public IActionResult OnPostBtnGetSelectedNode_Click(JObject selectedNode)
        {
            var labResult = UIHelper.Label("labResult");

            if (selectedNode.Count > 0)
            {
                labResult.Text(String.Format("选中的节点：{0}（{1}）", selectedNode.Value<string>("text"), selectedNode.Value<string>("id")));
            }
            else
            {
                labResult.Text("没有选中节点");
            }

            return UIHelper.Result();
        }


        public IActionResult OnPostBtnUpdateNode_Click(string hfDataSource)
        {
            var Tree1UI = UIHelper.Tree("Tree1");
            var hfDataSourceUI = UIHelper.HiddenField("hfDataSource");

            var source = hfDataSource == "source1" ? GetSource2() : GetSource1();
            Tree1UI.LoadData("zhumadian", source);
            // 展开更新后的节点
            Tree1UI.ExpandNode("zhumadian");

            UIHelper.HiddenField("hfDataSource").Text(hfDataSource == "source1" ? "source2" : "source1");

            return UIHelper.Result();
        }


        private List<TreeNode> GetSource2()
        {
            List<TreeNode> nodes = new List<TreeNode>();

            TreeNode node = null;

            node = new TreeNode();
            node.Text = "遂平县";
            node.Leaf = false;
            node.NodeID = "suiping";
            nodes.Add(node);

            var suipingNodes = node.Nodes;
            node = new TreeNode();
            node.Text = "槐树乡";
            node.Leaf = false;
            node.NodeID = "huaishu";
            suipingNodes.Add(node);

            var huaishuNodes = node.Nodes;
            node = new TreeNode();
            node.Text = "陈庄村";
            node.Leaf = true;
            node.NodeID = "chenzhuang";
            huaishuNodes.Add(node);

            node = new TreeNode();
            node.Text = "王老庄";
            node.Leaf = true;
            node.NodeID = "wanglaozhuang";
            huaishuNodes.Add(node);

            node = new TreeNode();
            node.Text = "嵖岈山乡";
            node.Leaf = true;
            node.NodeID = "chayashan";
            suipingNodes.Add(node);

            node = new TreeNode();
            node.Text = "西平县";
            node.Leaf = true;
            node.NodeID = "xiping";
            nodes.Add(node);

            return nodes;
        }

        private List<TreeNode> GetSource1()
        {
            List<TreeNode> nodes = new List<TreeNode>();

            TreeNode node = null;

            node = new TreeNode();
            node.Text = "平舆县";
            node.Leaf = true;
            node.NodeID = "pingyu";
            nodes.Add(node);

            node = new TreeNode();
            node.Text = "汝南县";
            node.Leaf = true;
            node.NodeID = "runan";
            nodes.Add(node);

            node = new TreeNode();
            node.Text = "新蔡县";
            node.Leaf = true;
            node.NodeID = "xincai";
            nodes.Add(node);

            return nodes;
        }

    }
}