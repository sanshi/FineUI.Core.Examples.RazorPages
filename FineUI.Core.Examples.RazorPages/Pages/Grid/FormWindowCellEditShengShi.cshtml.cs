using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using Newtonsoft.Json.Linq;


namespace FineUI.Core.Examples.RazorPages.Pages.Grid
{
    public class FormWindowCellEditShengShiModel : BaseModel
    {
        public void OnGet()
        {
            ViewBag.Grid1DataSource = GetSourceData();

            // 省和市的数据都放在客户端：省下拉列表的数据在后台绑定，市下拉列表的数据按省在前台动态加载
            ViewBag.StartupScript = String.Format("window._SHI={0};", DataSourceUtil.SHI_JSON.ToString());
        }


        // 全部保存：把客户端表格里改动过的行一次性提交上来
        public IActionResult OnPostBtnSaveAll_Click(string[] Grid1_fields, JArray Grid1_modifiedData)
        {
            if (Grid1_modifiedData.Count == 0)
            {
                UIHelper.Label("labResult").Text("");
                ShowNotify("表格数据没有变化！");

                return UIHelper.Result();
            }

            DataTable table = GetSourceData();

            // 修改与删除先处理；新增行要等删除处理完，行序才与客户端一致
            foreach (JObject modifiedRow in Grid1_modifiedData)
            {
                string status = modifiedRow.Value<string>("status");

                if (status == "modified")
                {
                    int rowID = Convert.ToInt32(modifiedRow.Value<string>("id"));
                    UpdateDataRow(modifiedRow, FindRowByID(table, rowID));
                }
                else if (status == "deleted")
                {
                    DeleteRowByID(table, Convert.ToInt32(modifiedRow.Value<string>("id")));
                }
            }

            // 新增行：客户端把它放在第几行，回发数据的 index 就是几，服务端照着插
            // （前提是表格不分页、也没在客户端排过序，否则 index 与数据源的行序对不上）
            foreach (JObject modifiedRow in Grid1_modifiedData)
            {
                if (modifiedRow.Value<string>("status") == "newadded")
                {
                    table.Rows.InsertAt(CreateNewData(table, modifiedRow), modifiedRow.Value<int>("index"));
                }
            }

            HttpContext.Session.SetObject<DataTable>(KEY_FOR_DATASOURCE_SESSION, table);

            UIHelper.Grid("Grid1").DataSource(table, Grid1_fields);
            UIHelper.Label("labResult").Text(String.Format("用户修改的数据：<pre>{0}</pre>", EncodeJson(Grid1_modifiedData)));

            ShowNotify("数据保存成功！（表格数据已重新绑定）");

            return UIHelper.Result();
        }


        #region UpdateDataRow

        private DataRow CreateNewData(DataTable table, JObject modifiedRow)
        {
            DataRow rowData = table.NewRow();

            // 设置行ID（模拟数据库的自增长列）
            rowData["Id"] = GetNextRowID(table);

            UpdateDataRow(modifiedRow, rowData);

            return rowData;
        }

        private void UpdateDataRow(JObject modifiedRow, DataRow rowData)
        {
            Dictionary<string, object> rowDict = modifiedRow.Value<JObject>("values").ToObject<Dictionary<string, object>>();

            UpdateDataRow("Name", rowDict, rowData);
            UpdateDataRow("Gender", rowDict, rowData);
            UpdateDataRow("EntranceYear", rowDict, rowData);
            UpdateDataRow("EntranceDate", rowDict, rowData);
            UpdateDataRow("AtSchool", rowDict, rowData);
            UpdateDataRow("Major", rowDict, rowData);
            UpdateDataRow("Sheng", rowDict, rowData);
            UpdateDataRow("Shi", rowDict, rowData);
        }

        #endregion


        #region Data

        private static readonly string KEY_FOR_DATASOURCE_SESSION = "Grid.FormWindowCellEditShengShi";

        // 模拟在服务器端保存数据
        // 特别注意：在真实的开发环境中，不要在Session放置大量数据，否则会严重影响服务器性能
        private DataTable GetSourceData()
        {
            if (HttpContext.Session.GetObject<DataTable>(KEY_FOR_DATASOURCE_SESSION) == null)
            {
                HttpContext.Session.SetObject(KEY_FOR_DATASOURCE_SESSION, GetDataTable());
            }
            return HttpContext.Session.GetObject<DataTable>(KEY_FOR_DATASOURCE_SESSION);
        }

        // 获取模拟表格（简单表格），比别的页面多出「省」和「市」两列
        // 省市都直接存名称，所以表格列不需要渲染函数把编码翻成名称
        public static DataTable GetDataTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("Id", typeof(int)));
            table.Columns.Add(new DataColumn("Name", typeof(string)));
            table.Columns.Add(new DataColumn("EntranceYear", typeof(int)));
            table.Columns.Add(new DataColumn("AtSchool", typeof(bool)));
            table.Columns.Add(new DataColumn("Major", typeof(string)));
            table.Columns.Add(new DataColumn("Gender", typeof(int)));
            table.Columns.Add(new DataColumn("EntranceDate", typeof(String)));
            table.Columns.Add(new DataColumn("Sheng", typeof(String)));
            table.Columns.Add(new DataColumn("Shi", typeof(String)));

            DataRow row = table.NewRow();
            row[0] = 101;
            row[1] = "张萍萍";
            row[2] = 2000;
            row[3] = true;
            row[4] = "材料科学与工程系";
            row[5] = 0;
            row[6] = "2000-09-01";
            row[7] = "北京";
            row[8] = "北京市";
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = 102;
            row[1] = "陈飞";
            row[2] = 2000;
            row[3] = false;
            row[4] = "化学系";
            row[5] = 1;
            row[6] = "2001-09-01";
            row[7] = "河北";
            row[8] = "秦皇岛市";
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = 103;
            row[1] = "董婷婷";
            row[2] = 2000;
            row[3] = true;
            row[4] = "化学系";
            row[5] = 0;
            row[6] = "2008-09-01";
            row[7] = "湖北";
            row[8] = "黄冈市";
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = 104;
            row[1] = "刘国";
            row[2] = 2002;
            row[3] = false;
            row[4] = "化学系";
            row[5] = 1;
            row[6] = "2002-09-01";
            row[7] = "安徽";
            row[8] = "合肥市";
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = 112;
            row[1] = "张三石";
            row[2] = 2012;
            row[3] = true;
            row[4] = "材料科学与工程系";
            row[5] = 1;
            row[6] = "2000-09-01";
            row[7] = "河南";
            row[8] = "驻马店市";
            table.Rows.Add(row);

            return table;
        }

        #endregion

    }
}
