using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.GridFilter
{
    public class FilterInitValueModel : BaseModel
    {
        public void OnGet()
        {
            JArray filteredData = new JArray(
                new JObject(
                    new JProperty("column", "Name"),
                    new JProperty("multi", false),
                    new JProperty("items",
                        new JArray(
                            new JObject(
                                new JProperty("value", "张")
                            )
                        )
                    )
                )
            );

            ViewBag.Grid1FilteredData = filteredData;
            ViewBag.Grid1DataSource = GetFilteredDataTable(filteredData);

            ViewBag.labResultText = String.Format("初始过滤数据：<pre>{0}</pre>", EncodeJson(filteredData));
        }



        public IActionResult OnPostGrid1_FilterChanged(string[] Grid1_fields, JArray Grid1_filteredData)
        {
            DataTable table = GetFilteredDataTable(Grid1_filteredData);

            UIHelper.Grid("Grid1").DataSource(table, Grid1_fields);

            UIHelper.Label("labResult").Text(String.Format("过滤数据：<pre>{0}</pre>", EncodeJson(Grid1_filteredData)));

            return UIHelper.Result();
        }

        private DataTable GetFilteredDataTable(JArray filteredData)
        {
            FilteredTable filteredTable = new FilteredTable();
            filteredTable.FilterDataRowItem = FilterDataRowItemImplement;

            DataTable table = filteredTable.GetFilteredTable(filteredData);

            return table;
        }


        public IActionResult OnPostBtnUpdateFilteredData_Click(string[] Grid1_fields)
        {
            JArray filteredData = new JArray(
                new JObject(
                    new JProperty("column", "Name"),
                    new JProperty("multi", false),
                    new JProperty("items",
                        new JArray(
                            new JObject(
                                new JProperty("value", "婷婷")
                            )
                        )
                    )
                )
            );

            
            UIHelper.Grid("Grid1").FilteredData(filteredData);

            DataTable table = GetFilteredDataTable(filteredData);
            UIHelper.Grid("Grid1").DataSource(table, Grid1_fields);

            UIHelper.Label("labResult").Text(String.Format("后台更新过滤数据：<pre>{0}</pre>", EncodeJson(filteredData)));

            return UIHelper.Result();
        }


        #region FilterDataRowItem

        private bool FilterDataRowItemImplement(object sourceObj, string fillteredOperator, JToken fillteredObj, string column)
        {
            bool valid = false;

            if (column == "Name")
            {
                string sourceValue = sourceObj.ToString();
                string fillteredValue = fillteredObj.Value<string>();

                if (sourceValue.Contains(fillteredValue))
                {
                    valid = true;
                }
            }

            return valid;
        }

        #endregion

    }
}