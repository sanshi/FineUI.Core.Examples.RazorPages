using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FineUI.Core.Examples.RazorPages.Pages.DataModel.Models;

namespace FineUI.Core.Examples.RazorPages.Pages.MultiLang
{

    public partial class UICompareAnnotationModel : BaseMultilangModel
    {
        public void OnGet()
        {
            TheModel = new Models.UICompareModel()
            {
                StartDate = DateTime.Now,
                Number1 = 30
            };
        }

        [BindProperty]
        public Models.UICompareModel TheModel { get; set; }


		public IActionResult OnPostBtnSubmit_Click()
        {
            if (ModelState.IsValid)
            {
                ShowNotify(_R("SuccessMessage", JsonConvert.SerializeObject(TheModel, Formatting.Indented)));
            }

            return UIHelper.Result();
        }
		
    }
}