using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;

namespace FineUI.Core.Examples.RazorPages.Pages.Mobile
{
    public class MainModel : MobilePageBase
    {
        public void OnGet()
        {
            LoadData();
        }

        private void LoadData()
        {
            XmlDocument doc = DataSourceUtil.LoadXml("~/wwwroot/res/menu.xml");
            XmlNode mobileRootNode = doc.SelectSingleNode("/Tree/TreeNode[@Text=\"移动\"]");

            JArray menuSource = new JArray();
            // 一级菜单
            foreach (XmlNode node in mobileRootNode.ChildNodes)
            {
                string menuText = node.Attributes["Text"].Value;

                if (menuText == "移动首页")
                {
                    continue; // 不添加本项
                }

                JObject menu = new JObject();
                menu.Add("text", menuText);

                ResolveXmlNode(node, menu);

                menuSource.Add(menu);
            }


            // 菜单标题和链接作为数据输出，避免把 XML 内容拼进可执行脚本。
            ViewBag.MenuDataJson = Newtonsoft.Json.JsonConvert.SerializeObject(
                menuSource,
                new Newtonsoft.Json.JsonSerializerSettings
                {
                    StringEscapeHandling = Newtonsoft.Json.StringEscapeHandling.EscapeHtml
                });
            
        }

        private void ResolveXmlNode(XmlNode node, JObject parentMenu)
        {
            // 二级菜单
            JArray subMenus = new JArray();
            foreach (XmlNode subnode in node.ChildNodes)
            {
                JObject subMenu = new JObject();
                string subMenuText = subnode.Attributes["Text"].Value;

                if (subnode.HasChildNodes)
                {
                    subMenu.Add("text", subMenuText);

                    ResolveXmlNode(subnode, subMenu);
                }
                else
                {
                    string subMenuNavigateUrl = subnode.Attributes["NavigateUrl"].Value;

                    subMenu.Add("text", subMenuText);
                    subMenu.Add("navigateUrl", Url.Content(subMenuNavigateUrl.Replace("/?file=", "/")));
                }

                subMenus.Add(subMenu);
            }

            parentMenu.Add("children", subMenus);
        }
    }
}
