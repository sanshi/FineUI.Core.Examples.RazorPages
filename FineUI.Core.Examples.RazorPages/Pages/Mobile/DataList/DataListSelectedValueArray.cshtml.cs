using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Mobile.DataList
{
    public class DataListSelectedValueArrayModel : BaseMobileModel
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
                listItem.TextRawHtml = new RawHtml(DATALIST_SIMPLE_ITEM_TEMPLATE,
                    Url.Content("~/res/icon/flag_" + row["Image"] + ".png"),
                    row["Name"]);
                listItem.Value = row["Id"].ToString();

                items.Add(listItem);
            }

            ViewBag.DataList1Items = items.ToArray();
        }


        public IActionResult OnPostBtnSubmit_Click(string[] selected)
        {
            Alert.Show("选中项：" + String.Join(", ", selected));

            return UIHelper.Result();
        }

    }
}