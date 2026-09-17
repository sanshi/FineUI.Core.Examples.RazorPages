using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using FineUI.Core.Examples.RazorPages.Pages.MultiLang.Models;
using Newtonsoft.Json.Linq;

namespace FineUI.Core.Examples.RazorPages.Pages.MultiLang
{
    
    public partial class GridAnnotationModel : BaseMultilangModel
    {
        public void OnGet()
        {
            Students = StudentHelper.GetSimpleStudentList();
        }

        public IList<Student> Students { get; set; }



    }
}