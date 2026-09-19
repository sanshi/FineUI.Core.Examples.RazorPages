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
    public class FormWindowModel : BaseModel
    {
        public void OnGet()
        {
            ViewBag.Grid1DataSource = GetSourceData();
        }


        // 删除选中行：行标识由客户端随自定义回发带上来，不用再让服务端从回发状态里反推
        public IActionResult OnPostGrid1_DeleteRows(string[] selectedRows, string[] fields)
        {
            DataTable table = GetSourceData();

            foreach (string rowID in selectedRows)
            {
                DeleteRowByID(table, Convert.ToInt32(rowID));
            }

            HttpContext.Session.SetObject<DataTable>(KEY_FOR_DATASOURCE_SESSION, table);

            UIHelper.Grid("Grid1").DataSource(table, fields);

            ShowNotify("删除数据成功!（表格数据已重新绑定）");

            return UIHelper.Result();
        }


        // 保存数据：表单里带行标识就是编辑，不带就是新增
        public IActionResult OnPostBtnSave_Click(IFormCollection values, string[] Grid1_fields)
        {
            DataTable table = GetSourceData();

            DataRow rowData;

            string strRowID = values["hfFormID"].ToString();
            if (String.IsNullOrEmpty(strRowID))
            {
                // 新增
                rowData = table.NewRow();

                // 设置行ID（模拟数据库的自增长列）
                rowData["Id"] = GetNextRowID(table);

                table.Rows.Add(rowData);
            }
            else
            {
                // 编辑
                rowData = FindRowByID(table, Convert.ToInt32(strRowID));
            }

            // 姓名
            rowData["Name"] = values["tbxFormUserName"].ToString().Trim();
            // 性别
            rowData["Gender"] = Convert.ToInt32(values["rblFormGender"].ToString());
            // 入学年份
            rowData["EntranceYear"] = Convert.ToInt32(values["nbFormEntranceYear"].ToString());
            // 入学日期
            rowData["EntranceDate"] = values["dpFormEntranceDate"].ToString();
            // 是否在校（复选框的回发值是 true / false 字符串）
            rowData["AtSchool"] = Convert.ToBoolean(values["cbFormAtSchool"].ToString());
            // 所学专业
            rowData["Major"] = values["ddlFormMajor"].ToString();

            HttpContext.Session.SetObject<DataTable>(KEY_FOR_DATASOURCE_SESSION, table);

            // 重新绑定表格，选中刚保存的那一行，并关闭弹出窗体
            UIHelper.Grid("Grid1").DataSource(table, Grid1_fields);
            RegisterStartupScript(String.Format("F.ui.Grid1.selectRow('{0}');", rowData["Id"]));
            UIHelper.Window("Window1").Hide();

            return UIHelper.Result();
        }


        #region Data

        private static readonly string KEY_FOR_DATASOURCE_SESSION = "Grid.FormWindow";

        // 模拟在服务器端保存数据
        // 特别注意：在真实的开发环境中，不要在Session放置大量数据，否则会严重影响服务器性能
        private DataTable GetSourceData()
        {
            if (HttpContext.Session.GetObject<DataTable>(KEY_FOR_DATASOURCE_SESSION) == null)
            {
                HttpContext.Session.SetObject(KEY_FOR_DATASOURCE_SESSION, DataSourceUtil.GetDataTable());
            }
            return HttpContext.Session.GetObject<DataTable>(KEY_FOR_DATASOURCE_SESSION);
        }

        #endregion

    }
}
