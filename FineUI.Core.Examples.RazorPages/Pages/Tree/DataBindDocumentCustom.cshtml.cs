using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml;

namespace FineUI.Core.Examples.RazorPages.Pages.Tree
{
    public class DataBindDocumentCustomModel : BaseModel
    {
        public void OnGet()
        {
            LoadData();


        }


        
        private void LoadData()
        {
            string xmlPath = FineUI.Core.PageContext.MapWebPath("~/content/tree/website.xml");

            string xmlContent = String.Empty;
            using (StreamReader sr = new StreamReader(xmlPath))
            {
                xmlContent = sr.ReadToEnd();
            }

            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(xmlContent);

            IList<TreeNode> nodes = new List<TreeNode>();
            ResolveXmlNodeList(nodes, xdoc.DocumentElement.ChildNodes);

            // 视图数据
            ViewBag.Tree1Nodes = nodes.ToArray();
        }

        private void ResolveXmlNodeList(IList<TreeNode> nodes, XmlNodeList xmlNodes)
        {
            foreach (XmlNode xmlNode in xmlNodes)
            {
                if (xmlNode.NodeType == XmlNodeType.Element)
                {
                    TreeNode node = new TreeNode();
                    nodes.Add(node);


                    foreach (XmlAttribute attribute in xmlNode.Attributes)
                    {
                        string name = attribute.Name;
                        string value = attribute.Value;

                        if (name == "Highlight")
                        {
                            node.CssClass = "highlight";
                        }
                        else
                        {
                            node.SetPropertyValue(name, value);
                        }
                    }

                    if (xmlNode.ChildNodes.Count > 0)
                    {
                        ResolveXmlNodeList(node.Nodes, xmlNode.ChildNodes);
                    }
                }
            }
        }


        public IActionResult OnPostTree1_NodeClick(JObject nodeInfo)
        {
            UIHelper.Label("labResult").Text(String.Format("你点击了树节点：{1}（{0}）{2}",
                nodeInfo.Value<string>("id"),
                nodeInfo.Value<string>("text"),
                nodeInfo.Value<bool>("highlight") ? " - 高亮显示" : ""));

            return UIHelper.Result();
        }

    }
}