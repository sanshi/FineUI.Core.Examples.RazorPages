using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Toolbar
{
    public class FormFieldsModel : BaseModel
    {
        public void OnGet()
        {

        }


        

        public IActionResult OnPostBtnClearDate_Click(string checkedValue)
        {
            UIHelper.DatePicker("dpStartDate").Reset();
            UIHelper.DatePicker("dpEndDate").Reset();

            UIHelper.Grid("Grid1").DataSource(null);

            return UIHelper.Result();
        }

        public IActionResult OnPostBtnSearch_Click(string[] Grid1_fields)
        {
            UIHelper.Grid("Grid1").DataSource(DataSourceUtil.GetDataTable(), Grid1_fields);

            return UIHelper.Result();
        }
        
       
    }
}