using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using FineUI.Core.Examples.RazorPages.Pages.DataModel.Models;

namespace FineUI.Core.Examples.RazorPages.Pages.DataModel
{
    public class GridModel : BaseModel
    {
        public void OnGet()
        {
            Students = StudentHelper.GetSimpleStudentList();
        }

        public IList<Student> Students { get; set; }



    }
}