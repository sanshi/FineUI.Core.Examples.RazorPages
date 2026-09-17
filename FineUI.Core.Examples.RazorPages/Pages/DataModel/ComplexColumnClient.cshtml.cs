using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FineUI.Core.Examples.RazorPages.Pages.DataModel.Models;

namespace FineUI.Core.Examples.RazorPages.Pages.DataModel
{
    public class ComplexColumnClientModel : BaseModel
    {
        public void OnGet()
        {
            Students = StudentHelper.GetSimpleStudentList<StudentExtended>();
        }


        public IList<StudentExtended> Students { get; set; }
        

    }
}