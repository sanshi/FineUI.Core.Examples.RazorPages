using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Grid
{
    public class GroupFieldManyColumnsModel : BaseModel
    {
        // 分组内部使用混合列宽，覆盖跨列分配时的累积舍入。
        private static readonly int[] LEAF_WIDTHS = { 70, 100, 110, 150 };
        // 叶子列表头文本：每月「发货」分组用全部 18 个，「开票」分组用前 17 个
        private static readonly string[] SubLeafNames = new string[]
        {
            "金额", "数量", "单价", "去年同期", "去年变化率", "环比", "本年累计", "累计占比", "完成率", "目标", "差额", "预测", "实际", "偏差", "均价", "折扣", "税额", "备注"
        };

        public void OnGet()
        {
            ViewBag.Grid1Columns = CreateGridColumns().ToArray();
            ViewBag.Grid1DataSource = GetDataTable();
        }


        // 列数太多（5 + 12 个月 × 每月 35 个叶子列，共 425 列），全部在代码里循环生成
        private List<GridColumn> CreateGridColumns()
        {
            List<GridColumn> columns = new List<GridColumn>();

            // 序号列放在第一位
            columns.Add(new RowNumberField());

            // 前 5 列为锁定列：客户编号 / 客户名称 / 产品 / 期初 / 期末
            columns.Add(CreateLockedField("客户编号", "khbh", 90));
            columns.Add(CreateLockedField("客户名称", "khmc", 150));
            columns.Add(CreateLockedField("产品", "product", 100));
            columns.Add(CreateLockedField("期初", "qc", 90));
            columns.Add(CreateLockedField("期末", "qm", 90));

            // 12 个月，每月一个分组，月下再分「发货 / 开票」两个子分组
            for (int mo = 1; mo <= 12; mo++)
            {
                GroupField fhGroup = new GroupField();
                fhGroup.HeaderText = "发货";
                fhGroup.TextAlign = TextAlign.Center;
                for (int i = 0; i < 18; i++)
                {
                    fhGroup.Columns.Add(CreateLeafField(SubLeafNames[i], "m" + mo + "_fh_" + i, i));
                }

                GroupField kpGroup = new GroupField();
                kpGroup.HeaderText = "开票";
                kpGroup.TextAlign = TextAlign.Center;
                for (int j = 0; j < 17; j++)
                {
                    kpGroup.Columns.Add(CreateLeafField(SubLeafNames[j], "m" + mo + "_kp_" + j, j));
                }

                GroupField monthGroup = new GroupField();
                monthGroup.HeaderText = mo + "月";
                monthGroup.TextAlign = TextAlign.Center;
                monthGroup.Columns.Add(fhGroup);
                monthGroup.Columns.Add(kpGroup);

                columns.Add(monthGroup);
            }

            return columns;
        }

        private RenderField CreateLockedField(string headerText, string dataField, int width)
        {
            RenderField field = new RenderField();
            field.HeaderText = headerText;
            field.DataField = dataField;
            field.Width = width;
            field.Locked = true;
            return field;
        }

        private RenderField CreateLeafField(string headerText, string dataField, int leafIndex)
        {
            RenderField field = new RenderField();
            field.HeaderText = headerText;
            field.DataField = dataField;
            field.Width = LEAF_WIDTHS[leafIndex % LEAF_WIDTHS.Length];
            field.TextAlign = TextAlign.Right;
            return field;
        }


        private DataTable GetDataTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("Id", typeof(int)));
            table.Columns.Add(new DataColumn("khbh", typeof(string)));
            table.Columns.Add(new DataColumn("khmc", typeof(string)));
            table.Columns.Add(new DataColumn("product", typeof(string)));
            table.Columns.Add(new DataColumn("qc", typeof(double)));
            table.Columns.Add(new DataColumn("qm", typeof(double)));

            // 12 个月的所有叶子字段（与列定义一一对应）
            for (int mo = 1; mo <= 12; mo++)
            {
                for (int i = 0; i < 18; i++)
                {
                    table.Columns.Add(new DataColumn("m" + mo + "_fh_" + i, typeof(double)));
                }
                for (int j = 0; j < 17; j++)
                {
                    table.Columns.Add(new DataColumn("m" + mo + "_kp_" + j, typeof(double)));
                }
            }


            Random rd = new Random();
            for (int i = 0; i < 20; i++)
            {
                DataRow row = table.NewRow();
                row["Id"] = 100 + i;
                row["khbh"] = "HT0100" + (i % 5 + 1);
                row["khmc"] = "客户" + i;
                row["product"] = "产品" + (i % 8);
                row["qc"] = Math.Round(rd.NextDouble() * 1000, 2);
                row["qm"] = Math.Round(rd.NextDouble() * 1000, 2);

                for (int c = 6; c < table.Columns.Count; c++)
                {
                    row[c] = Math.Round(rd.NextDouble() * 5000, 2);
                }

                table.Rows.Add(row);
            }

            return table;
        }


    }
}
