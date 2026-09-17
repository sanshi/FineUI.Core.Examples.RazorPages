using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.DropDownList
{
    public class DataBindDataTableModel : BaseModel
    {
        public void OnGet()
        {
            LoadData();


        }


        
        
        private void LoadData()
        {
            DataTable table = new DataTable();
            DataColumn column1 = new DataColumn("MyText", typeof(String));
            DataColumn column2 = new DataColumn("MyValue", typeof(String));
            table.Columns.Add(column1);
            table.Columns.Add(column2);

            DataRow row = table.NewRow();
            row[0] = "可选项1";
            row[1] = "1";
            table.Rows.Add(row);
            row = table.NewRow();

            row[0] = "可选项2";
            row[1] = "2";
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = "可选项3";
            row[1] = "3";
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = "可选项4";
            row[1] = "4";
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = "可选项5";
            row[1] = "5";
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = "可选项6";
            row[1] = "6";
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = "可选择项7";
            row[1] = "7";
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = "可选择项8";
            row[1] = "8";
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = "可选择项9";
            row[1] = "9";
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = "这是一个很长很长很长很长很长很长很长很长很长很长很长很长很长很长很长很长的可选项";
            row[1] = "10";
            table.Rows.Add(row);


            ViewBag.DropDownList1DataSource = table;

        }

        public IActionResult OnPostBtnGetSelection_Click(string DropDownList1, string DropDownList1_text)
        {
            UIHelper.Label("labResult").Text(String.Format("选中项：{0}（值：{1}）", DropDownList1_text, DropDownList1));

            return UIHelper.Result();
        }

        public IActionResult OnPostBtnSelectItem6_Click()
        {
            UIHelper.DropDownList("DropDownList1").SelectedValue("6");

            return UIHelper.Result();
        }


    }
}