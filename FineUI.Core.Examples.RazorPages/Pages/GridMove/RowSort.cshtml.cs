using System;
using System.Data;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace FineUI.Core.Examples.RazorPages.Pages.GridMove
{
    public class RowSortModel : PageBase
    {
        private const string SavedOrderSessionKey = "GridMove.RowSort";

        public void OnGet()
        {
            ViewBag.Grid1DataSource = LoadData(HttpContext.Session.GetObject<string[]>(SavedOrderSessionKey));
        }

        private static DataTable LoadData(string[] savedOrder)
        {
            var students = DataSourceUtil.GetDataTable();
            if (savedOrder == null)
            {
                return students;
            }

            // 只保存行 ID。新加入的学生若没有保存位置，按初始顺序追加在已排序学生之后。
            var sortedStudents = students.Clone();
            var sortedRows = students.Rows.Cast<DataRow>().OrderBy(row =>
            {
                int index = Array.IndexOf(savedOrder, row["Id"].ToString());
                return index >= 0 ? index : int.MaxValue;
            });
            foreach (var row in sortedRows)
            {
                sortedStudents.ImportRow(row);
            }
            return sortedStudents;
        }

        public IActionResult OnPostBtnSaveToDB_Click(JArray rowIds)
        {
            HttpContext.Session.SetObject(SavedOrderSessionKey, rowIds.ToObject<string[]>());
            ShowNotify("数据保存成功！");
            return UIHelper.Result();
        }
    }
}
