using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.GridPaging
{
    public class PageItemsModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostBtnClearData_Click()
        {
            UIHelper.Grid("Grid1").DataSource(null);

            return UIHelper.Result();
        }

        public IActionResult OnPostBtnRebindData_Click(string[] fields)
        {
            UIHelper.Grid("Grid1").DataSource(DataSourceUtil.GetDataTable2(), fields);

            return UIHelper.Result();
        }

        public IActionResult OnPostBtnSelectAll_Click()
        {
            UIHelper.Grid("Grid1").SelectAllRows();

            return UIHelper.Result();
        }


        public IActionResult OnPostBtnClearSelect_Click()
        {
            UIHelper.Grid("Grid1").DeselectAllRows();

            return UIHelper.Result();
        }

    }
}