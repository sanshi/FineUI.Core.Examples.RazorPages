using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using Newtonsoft.Json.Linq;


namespace FineUI.Core.Examples.RazorPages.Pages.GridOther
{
    public class ManyColumnsModel : BaseModel
    {
        public void OnGet()
        {
            LoadData();


        }


        
        private void LoadData()
        {
            DataTable table = DataSourceUtil.GetDataTable();

            int newtableID = 101;
            DataTable newtable = table.Clone();
            for (int i = 0; i <= 2; i++)
            {
                foreach (DataRow row in table.Rows)
                {
                    row["Id"] = newtableID;
                    newtable.ImportRow(row);

                    newtableID++;
                }
            }

            ViewBag.Grid1DataSource = newtable;
        }



    }
}