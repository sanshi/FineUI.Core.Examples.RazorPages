using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;

namespace FineUI.Core.Examples.RazorPages.Pages.GridFilter
{
    public class InlineFilterComplexInitValueModel : BaseModel
    {
        public void OnGet()
        {
            JArray filteredData = new JArray(
                // EntranceYear
                new JObject(
                    new JProperty("column", "EntranceYear"),
                    new JProperty("multi", true),
                    new JProperty("matcher", "all"),
                    new JProperty("items", new JArray(
                        new JObject(
                            new JProperty("operator", "greater"),
                            new JProperty("value", 2008)
                        ),
                        new JObject(
                            new JProperty("operator", "less"),
                            new JProperty("value", 2025)
                        )
                    ))
                ),

                // Major
                new JObject(
                    new JProperty("column", "Major"),
                    new JProperty("multi", false),
                    new JProperty("items", new JArray(
                        new JObject(
                            new JProperty("value", new JArray(
                                "化学系", "物理系", "数学系"
                            ))
                        )
                    ))
                ),

                // Group
                new JObject(
                    new JProperty("column", "Group"),
                    new JProperty("multi", false),
                    new JProperty("items", new JArray(
                        new JObject(
                            new JProperty("value", new JArray(
                                "2", "3"
                            ))
                        )
                    ))
                )
            );


            ViewBag.Grid1FilteredData = filteredData;
            ViewBag.Grid1DataSource = GetFilteredDataTable(filteredData);

            ViewBag.labResultText = String.Format("初始过滤数据：<pre>{0}</pre>", EncodeJson(filteredData));

            InitFilterGroupList();

        }


        private void InitFilterGroupList()
        {
            List<ListItem> items = new List<ListItem>();
            for (int i = 1; i <= 5; i++)
            {
                ListItem item = new ListItem();
                item.Value = i.ToString();
                item.Text = String.Format("分组{0}", i);
                item.Display = String.Format("<img src=\"{0}\">&nbsp;{1}", Url.Content("~/res/images/16/" + i.ToString() + ".png"), item.Text);

                items.Add(item);
            }

            ViewBag.groupListItems = items.ToArray();
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
                // Gender
                new JObject(
                    new JProperty("column", "Gender"),
                    new JProperty("multi", false),
                    new JProperty("items", new JArray(
                        new JObject(
                            new JProperty("value", 1)
                        )
                    ))
                ),

                // EntranceYear
                new JObject(
                    new JProperty("column", "EntranceYear"),
                    new JProperty("multi", true),
                    new JProperty("matcher", "all"),
                    new JProperty("items", new JArray(
                        new JObject(
                            new JProperty("operator", "greater"),
                            new JProperty("value", 2008)
                        ),
                        new JObject(
                            new JProperty("operator", "less"),
                            new JProperty("value", 2025)
                        )
                    ))
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
                string fillteredValue = fillteredObj.Value<string>();  //fillteredObj.ToString();
                if (fillteredOperator == "equal")
                {
                    if (sourceValue == fillteredValue)
                    {
                        valid = true;
                    }
                }
                else if (fillteredOperator == "contain")
                {
                    if (sourceValue.Contains(fillteredValue))
                    {
                        valid = true;
                    }
                }
                else if (fillteredOperator == "start")
                {
                    if (sourceValue.StartsWith(fillteredValue))
                    {
                        valid = true;
                    }
                }
                else if (fillteredOperator == "end")
                {
                    if (sourceValue.EndsWith(fillteredValue))
                    {
                        valid = true;
                    }
                }
            }
            else if (column == "EntranceYear")
            {
                int sourceValue = Convert.ToInt32(sourceObj);
                int fillteredValue = fillteredObj.Value<int>(); //Convert.ToInt32(fillteredObj);

                if (fillteredOperator == "greater")
                {
                    if (sourceValue > fillteredValue)
                    {
                        valid = true;
                    }
                }
                else if (fillteredOperator == "less")
                {
                    if (sourceValue < fillteredValue)
                    {
                        valid = true;
                    }
                }
                else if (fillteredOperator == "equal")
                {
                    if (sourceValue == fillteredValue)
                    {
                        valid = true;
                    }
                }

            }
            else if (column == "LogTime")
            {
                // 时间比较时要去掉数据源中的时分秒！
                DateTime sourceDate = Convert.ToDateTime(sourceObj);
                DateTime sourceValue = new DateTime(sourceDate.Year, sourceDate.Month, sourceDate.Day);

                DateTime fillteredValue = fillteredObj.Value<DateTime>(); //Convert.ToDateTime(fillteredObj);

                if (fillteredOperator == "greater")
                {
                    if (sourceValue > fillteredValue)
                    {
                        valid = true;
                    }
                }
                else if (fillteredOperator == "less")
                {
                    if (sourceValue < fillteredValue)
                    {
                        valid = true;
                    }
                }
                else if (fillteredOperator == "equal")
                {
                    if (sourceValue == fillteredValue)
                    {
                        valid = true;
                    }
                }

            }
            else if (column == "Major" || column == "Group")
            {
                string sourceValue = sourceObj.ToString();
                JArray fillteredValue = (JArray)fillteredObj;  //(JArray)fillteredObj;

                foreach (string filltereditem in fillteredValue)
                {
                    if (filltereditem == sourceValue)
                    {
                        valid = true;
                        break;
                    }
                }
            }
            else if (column == "AtSchool")
            {
                bool sourceValue = Convert.ToBoolean(sourceObj);
                bool fillteredValue = fillteredObj.Value<bool>();  //Convert.ToBoolean(fillteredObj);

                if (sourceValue == fillteredValue)
                {
                    valid = true;
                }
            }
            else if (column == "Gender")
            {
                int sourceValue = Convert.ToInt32(sourceObj);
                int fillteredValue = fillteredObj.Value<int>();  //Convert.ToInt32(fillteredObj);

                if (sourceValue == fillteredValue)
                {
                    valid = true;
                }
            }


            return valid;
        }

        #endregion


    }
}
