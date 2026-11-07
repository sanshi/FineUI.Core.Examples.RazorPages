using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Toolbar
{
    public class FormFieldsModel : PageBase
    {
        public void OnGet()
        {

        }


        

        public IActionResult OnPostBtnClearDate_Click(string[] Grid1_fields)
        {
            UIHelper.DatePicker("dpStartDate").Reset();
            UIHelper.DatePicker("dpEndDate").Reset();

            // 清空记录时保留字段定义，确保下一次查询仍能按姓名、性别等字段显示数据。
            UIHelper.Grid("Grid1").DataSource(dataSource: null, fields: Grid1_fields);

            return UIHelper.Result();
        }

        public IActionResult OnPostBtnSearch_Click(string[] Grid1_fields)
        {
            UIHelper.Grid("Grid1").DataSource(DataSourceUtil.GetDataTable(), Grid1_fields);

            return UIHelper.Result();
        }
        
       
    }
}
