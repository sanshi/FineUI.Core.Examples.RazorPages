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
    public class SortingClientMultiModel : BaseModel
    {
        public void OnGet()
        {
            LoadData();


        }


        
        private void LoadData()
        {
            string[] sortFields = new string[] { "Gender", "ASC" };

            ViewBag.Grid1DataSource = GetSortedDataTable(sortFields);

            ViewBag.Grid1SortFields = sortFields;
        }

        private DataTable GetSortedDataTable(string[] sortFields)
        {
            List<string> sortItems = new List<string>();
            for (var i = 0; i < sortFields.Length; i += 2)
            {
                sortItems.Add(String.Format("{0} {1}", sortFields[i], sortFields[i + 1]));
            }

            DataTable table = DataSourceUtil.GetDataTable();
            DataView view1 = table.DefaultView;
            view1.Sort = String.Join(", ", sortItems);

            return view1.ToTable();
        }


    }
}