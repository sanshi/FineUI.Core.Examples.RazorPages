using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Data;

namespace FineUI.Core.Examples.RazorPages.Pages.GridFilter
{
    public class DropDownListNoForceSelectionModel : BaseModel
    {
        public void OnGet()
        {

        }



        public IActionResult OnPostGrid1_FilterChanged(string[] Grid1_fields, JArray Grid1_filteredData)
        {
            FilteredTable filteredTable = new FilteredTable();
            filteredTable.NewFilterDataRowItem = NewFilterDataRowItemImplement;

            DataTable table = filteredTable.GetFilteredTable(Grid1_filteredData);

            UIHelper.Grid("Grid1").DataSource(table, Grid1_fields);

            UIHelper.Label("labResult").Text(String.Format("过滤数据：<pre>{0}</pre>", EncodeJson(Grid1_filteredData)));

            return UIHelper.Result();
        }


        #region FilterDataRowItem

        private bool NewFilterDataRowItemImplement(object sourceObj, string itemOperator, JToken itemValue, string itemText, string column)
        {
            bool valid = false;

            if (column == "Major")
            {
                string sourceValue = sourceObj.ToString();

                // 下拉列表的值是数组，并且数组不为空
                if (itemValue is JArray && (itemValue as JArray).Count > 0)
                {
                    JArray fillteredValue = (JArray)itemValue;

                    foreach (string filltereditem in fillteredValue)
                    {
                        if (filltereditem == sourceValue)
                        {
                            valid = true;
                            break;
                        }
                    }
                }
                else
                {
                    // 下拉列表，用户输入值
                    //string fillteredValue = fillteredObj.Value<string>();
                    if (sourceValue.Contains(itemText))
                    {
                        valid = true;
                    }
                }

            }

            return valid;
        }


        #endregion

    }
}
