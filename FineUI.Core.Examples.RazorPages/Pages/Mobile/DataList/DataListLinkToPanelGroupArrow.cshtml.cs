using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Mobile.DataList
{
    public class DataListLinkToPanelGroupArrowModel : BaseMobileModel
    {
        public void OnGet()
        {
            LoadData();


        }


        
        protected static readonly string DATALIST_ITEM_TEMPLATE_CHINA = "<table class=\"item-table\"><tr><td><img class=\"item-img\" src=\"{0}\"><div class=\"item-text\">{1}</div><div class=\"item-desc china\">{2}</div></td></tr></table>";


        private void LoadData()
        {
            DataTable source = DataSourceUtil.GetCountryTable();

            List<DataListItem> items = new List<DataListItem>();
            foreach (DataRow row in source.Rows)
            {
                DataListItem listItem = new DataListItem();

                string name = row["Name"].ToString();
                string groupName = row["Group"].ToString();

                listItem.Group = groupName;

                if (name == "中国")
                {
                    listItem.TextRawHtml = new RawHtml(DATALIST_ITEM_TEMPLATE_CHINA,
                        Url.Content("~/res/icon/flag_" + row["Image"] + ".png"),
                        HttpUtility.HtmlEncode(row["Name"]),
                        HttpUtility.HtmlEncode(row["Desc"]));
                }
                else
                {
                    listItem.TextRawHtml = new RawHtml(DATALIST_ITEM_TEMPLATE,
                        Url.Content("~/res/icon/flag_" + row["Image"] + ".png"),
                        HttpUtility.HtmlEncode(row["Name"]),
                        HttpUtility.HtmlEncode(row["Desc"]));

                    listItem.NavigateUrl = "javascript:;";

                    // 属于欧洲的子项，显示右侧箭头
                    if (groupName == "欧洲")
                    {
                        listItem.ShowArrow = true;
                    }

                }


                items.Add(listItem);
            }

            ViewBag.DataList1Items = items.ToArray();
        }


    }
}