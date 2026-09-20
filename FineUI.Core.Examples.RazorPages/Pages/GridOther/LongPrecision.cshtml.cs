using System;
using System.Data;

namespace FineUI.Core.Examples.RazorPages.Pages.GridOther
{
    public class LongPrecisionModel : BaseModel
    {
        public void OnGet()
        {
            // 两个表格绑定同一份数据：表格一使用默认配置，表格二显式关闭长整型转换
            ViewBag.GridDataSource = GetSimpleDataTable();
        }

        /// <summary>
        /// 构造演示数据：第一行的 Id 是超过 JavaScript 安全整数范围的 17 位长整型
        /// </summary>
        public static DataTable GetSimpleDataTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("Id", typeof(long)));
            table.Columns.Add(new DataColumn("Name", typeof(String)));
            table.Columns.Add(new DataColumn("EntranceYear", typeof(int)));
            table.Columns.Add(new DataColumn("AtSchool", typeof(bool)));
            table.Columns.Add(new DataColumn("Major", typeof(String)));
            table.Columns.Add(new DataColumn("Gender", typeof(int)));
            table.Columns.Add(new DataColumn("EntranceDate", typeof(String)));


            DataRow row = table.NewRow();
            row[0] = 21956392701267968;
            row[1] = "张萍萍";
            row[2] = 2000;
            row[3] = true;
            row[4] = "材料科学与工程系";
            row[5] = 0;
            row[6] = "2000-09-01";
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = 102;
            row[1] = "陈飞";
            row[2] = 2000;
            row[3] = false;
            row[4] = "化学系";
            row[5] = 1;
            row[6] = "2001-09-01";
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = 103;
            row[1] = "董婷婷";
            row[2] = 2000;
            row[3] = true;
            row[4] = "化学系";
            row[5] = 0;
            row[6] = "2008-09-01";
            table.Rows.Add(row);

            return table;
        }
    }
}
