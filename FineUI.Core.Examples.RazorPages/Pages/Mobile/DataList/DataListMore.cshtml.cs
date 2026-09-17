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
    public class DataListMoreModel : BaseMobileModel
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
            return GetSource(GetDataByIndex(0));
        }

        private DataTable GetDataByIndex(int dataIndex)
        {
            DataTable table = DataSourceUtil.GetCountryTable();
            if (dataIndex > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    var rowId = row["Id"].ToString();
                    var rowName = row["Name"].ToString();

                    row["Id"] = rowId + '_' + (dataIndex + 1).ToString();
                    row["Name"] = rowName + ' ' + (dataIndex + 1).ToString();
                }
            }
            return table;
        }

        private void LoadNextData(int dataIndex)
        {
            dataIndex++;

            var DataList1 = UIHelper.DataList("DataList1");
            if (dataIndex <= 4)
            {
                var dataSource = GetSource(GetDataByIndex(dataIndex));

                // AppendData: 追加数据
                DataList1.AppendData(dataSource);
                DataList1.Attribute("data-index", dataIndex.ToString());
            }

            var btnMore = UIHelper.LinkButton("btnMore");
            if (dataIndex == 4)
            {
                btnMore.Enabled(false);
                btnMore.Text("全部加载完毕");
            }
        }


        public IActionResult OnPostBtnMore_Click(int dataIndex)
        {
            LoadNextData(dataIndex);
            
            return UIHelper.Result();
        }

    }
}