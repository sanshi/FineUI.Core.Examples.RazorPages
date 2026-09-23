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
    public class DataListLinkToPanelGroupModel : BaseMobileModel
    {
        public void OnGet()
        {
            LoadData();


        }


        

        private void LoadData()
        {
            DataTable source = DataSourceUtil.GetCountryTable();

            List<DataListItem> items = new List<DataListItem>();
            foreach (DataRow row in source.Rows)
            {
                DataListItem listItem = new DataListItem();
                listItem.TextRawHtml = new RawHtml(DATALIST_ITEM_TEMPLATE,
                    Url.Content("~/res/icon/flag_" + row["Image"] + ".png"),
                    HttpUtility.HtmlEncode(row["Name"]),
                    HttpUtility.HtmlEncode(row["Desc"]));

                listItem.NavigateUrl = "#";
                listItem.ShowArrow = true;
                listItem.Group = row["Group"].ToString();


                items.Add(listItem);
            }

            ViewBag.DataList1Items = items.ToArray();
        }


    }
}