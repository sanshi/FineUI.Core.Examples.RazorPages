using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FineUI.Core.Examples.RazorPages.Pages.DataModel.Models;

namespace FineUI.Core.Examples.RazorPages.Pages.DataModel
{
    public class GridSortingQuickSortFieldModel : BaseModel
    {
        public IList<Student> Students { get; set; }

        public void OnGet()
        {
            LoadData();

        }

        private void LoadData()
        {
            string sortField = "Gender";
            string sortDirection = "ASC";

            ViewBag.Grid1SortField = sortField;
            ViewBag.Grid1SortDirection = sortDirection;

            Students = GetSortedDataTable(sortField, sortDirection);

        }

        private IList<Student> GetSortedDataTable(string sortField, string sortDirection)
        {
            var students = StudentHelper.GetSimpleStudentList().ToList();
            students.Sort((left, right) =>
            {
                if (sortField == "Name")
                {
                    return sortDirection == "ASC" ? left.Name.CompareTo(right.Name) : right.Name.CompareTo(left.Name);
                }
                else if (sortField == "Gender")
                {
                    return sortDirection == "ASC" ? left.Gender.CompareTo(right.Gender) : right.Gender.CompareTo(left.Gender);
                }
                else if (sortField == "EntranceYear")
                {
                    return sortDirection == "ASC" ? left.EntranceYear.CompareTo(right.EntranceYear) : right.EntranceYear.CompareTo(left.EntranceYear);
                }
                else if (sortField == "AtSchool")
                {
                    return sortDirection == "ASC" ? left.AtSchool.CompareTo(right.AtSchool) : right.AtSchool.CompareTo(left.AtSchool);
                }
                return 0;
            });

            return students;
        }


        public IActionResult OnPostGrid1_Sort(string[] Grid1_fields, string Grid1_sortField, string Grid1_sortDirection)
        {
            // 更新表格数据源
            UIHelper.Grid("Grid1").DataSource(GetSortedDataTable(Grid1_sortField, Grid1_sortDirection), Grid1_fields);

            return UIHelper.Result();
        }

    }
}