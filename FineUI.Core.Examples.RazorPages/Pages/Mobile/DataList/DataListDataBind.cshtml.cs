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
    public class DataListDataBindModel : BaseMobileModel
    {
        public void OnGet()
        {
            LoadData();


        }


        
        private void LoadData()
        {
            ViewBag.DataList1Items = GetSource1();
        }



        private DataListItem[] GetSource(DataTable source)
        {
            List<DataListItem> items = new List<DataListItem>();
            foreach (DataRow row in source.Rows)
            {
                DataListItem listItem = new DataListItem();
                listItem.TextRawHtml = new RawHtml(DATALIST_ITEM_TEMPLATE,
                    Url.Content("~/res/icon/flag_" + row["Image"] + ".png"),
                    HttpUtility.HtmlEncode(row["Name"]),
                    HttpUtility.HtmlEncode(row["Desc"]));

                items.Add(listItem);
            }

            return items.ToArray();
        }

        private DataListItem[] GetSource1()
        {
            return GetSource(DataSourceUtil.GetCountryTable());
        }

        private DataListItem[] GetSource2()
        {
            return GetSource(DataSourceUtil.GetCountryTable2());
        }

        public IActionResult OnPostBtnReDataBind_Click(string source)
        {
            var dataList1 = UIHelper.DataList("DataList1");

            if (source == "source1")
            {
                dataList1.LoadData(GetSource2());
                dataList1.Attribute("data-source-key", "source2");
            }
            else
            {
                dataList1.LoadData(GetSource1());
                dataList1.Attribute("data-source-key", "source1");
            }

            return UIHelper.Result();
        }

    }
}