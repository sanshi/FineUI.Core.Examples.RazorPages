using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.DropDownBox
{
    public class NestingModel : BaseModel
    {
        public void OnGet()
        {
            ViewBag.SourceDataTable = GetFilteredData();


        }


        
        private DataTable GetFilteredData()
        {
            return GetFilteredData(null, null);
        }

        private DataTable GetFilteredData(string gender, string[] majors)
        {
            DataTable table = DataSourceUtil.GetDataTable();

            DataView view = table.DefaultView;

            List<string> filters = new List<string>();

            // 性别过滤
            if (!String.IsNullOrEmpty(gender))
            {
                filters.Add(String.Format("Gender = {0}", gender));
            }

            // 专业过滤
            if (majors != null && majors.Length > 0)
            {
                List<string> majorFilters = new List<string>();
                foreach (string ddb in majors)
                {
                    majorFilters.Add(String.Format("Major = '{0}'", ddb));
                }
                filters.Add("(" + String.Join(" OR ", majorFilters.ToArray()) + ")");
            }

            if (filters.Count > 0)
            {
                view.RowFilter = String.Join(" AND ", filters.ToArray());
            }

            return table;
        }

        private void BindGrid(string ddlGender, string[] ddbMajor, string[] Grid1_fields)
        {
            UIHelper.Grid("Grid1").DataSource(GetFilteredData(ddlGender, ddbMajor), Grid1_fields);
        }

        public IActionResult OnPostDdlGender_SelectedIndexChanged(string ddlGender, string[] ddbMajor, string[] Grid1_fields)
        {
            BindGrid(ddlGender, ddbMajor, Grid1_fields);
            return UIHelper.Result();
        }

        public IActionResult OnPostDdbMajor_TextChanged(string ddlGender, string[] ddbMajor, string[] Grid1_fields)
        {
            BindGrid(ddlGender, ddbMajor, Grid1_fields);
            return UIHelper.Result();
        }

        public IActionResult OnPostBtnGetSelection_Click(string[] DropDownBox1, string DropDownBox1_text)
        {
            var labResult = UIHelper.Label("labResult");
            if (DropDownBox1 != null && DropDownBox1.Length > 0)
            {
                labResult.Text(String.Format("下拉框文本：{0}（值：{1}）", DropDownBox1_text, String.Join(", ", DropDownBox1)));
            }
            else
            {
                labResult.Text("下拉框为空");
            }

            return UIHelper.Result();
        }


    }
}