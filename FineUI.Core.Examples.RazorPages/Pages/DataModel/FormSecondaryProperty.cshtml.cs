using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using FineUI.Core.Examples.RazorPages.Pages.DataModel.Models;

namespace FineUI.Core.Examples.RazorPages.Pages.DataModel
{
    public class FormSecondaryPropertyModel : BaseModel
    {
        public void OnGet()
        {
            var model = new Student
            {
                Id = 101,
                Name = "张萍萍",
                Gender = 0,
                EntranceYear = 2000,
                AtSchool = true,
                Major = "材料科学与工程系",
                Group = 1,
                EntranceDate = DateTime.Parse("2024-09-01 10:10:30"),
                Score = new Score
                {
                    Chinese = 80,
                    Math = 100,
                    Physics = 88,
                    Chemistry = 79
                }
            };

            Student = model;
        }

        [BindProperty]
        public Student Student { get; set; }
        

        public IActionResult OnPostBtnSubmit_Click(IFormCollection values)
        {
            if (ModelState.IsValid)
            {
                Student.Group = 1;
                Student.EntranceYear = Student.EntranceDate.Value.Year;
                
                ShowNotify(new RawHtml("用户提交的数据：<br/><pre>{0}</pre>", EncodeJson(Student)));
            }

            return UIHelper.Result();
        }

    }
}