using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Grid
{
    public class CustomHeadMenuModel : BaseModel
    {
        public void OnGet()
        {

        }


        

        private void BindGrid(string[] Grid1_fields, JObject menuStatus)
        {
            string menu1 = menuStatus.Value<string>("menu1");
            string menu2 = menuStatus.Value<string>("menu2");

            DataTable table = DataSourceUtil.GetDataTable();

            DataView view = table.DefaultView;

            List<string> filters = new List<string>();
            if (menu1 == "在校")
            {
                filters.Add("AtSchool=1");
            }
            else if (menu1 == "离校")
            {
                filters.Add("AtSchool=0");
            }

            if (menu2 == "入学年份大于2002")
            {
                filters.Add("EntranceYear>2002");
            }

            if (filters.Count > 0)
            {
                view.RowFilter = String.Join(" AND ", filters.ToArray());
            }

            UIHelper.Grid("Grid1").DataSource(view.ToTable(), Grid1_fields);
        }


        public IActionResult OnPostBtnAtSchool_CheckedChanged(string[] Grid1_fields, JObject menuStatus)
        {
            BindGrid(Grid1_fields, menuStatus);
            return UIHelper.Result();
        }


        public IActionResult OnPostBtnEntranceYear_CheckedChanged(string[] Grid1_fields, JObject menuStatus)
        {
            BindGrid(Grid1_fields, menuStatus);
            return UIHelper.Result();
        }

    }
}