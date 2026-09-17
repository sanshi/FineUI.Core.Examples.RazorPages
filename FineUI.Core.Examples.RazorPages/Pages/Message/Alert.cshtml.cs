using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

namespace FineUI.Core.Examples.RazorPages.Pages.Message
{
    public class AlertModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostBtnSubmit_Click(IFormCollection values)
        {
            Alert alert = new Alert();
            alert.Message = values["tbxMessage"];
            alert.Title = values["tbxTitle"];
            alert.MessageBoxIcon = (MessageBoxIcon)Enum.Parse(typeof(MessageBoxIcon), values["rblMessageBoxIcon"], true);
            alert.Target = (Target)Enum.Parse(typeof(Target), values["rblTarget"], true);

            if (!String.IsNullOrEmpty(values["nbWidth"]))
            {
                alert.Width = Convert.ToInt32(values["nbWidth"]);
            }

            if (!String.IsNullOrEmpty(values["nbMinWidth"]))
            {
                alert.MinWidth = Convert.ToInt32(values["nbMinWidth"]);
            }

            if (!String.IsNullOrEmpty(values["nbMaxWidth"]))
            {
                alert.MaxWidth = Convert.ToInt32(values["nbMaxWidth"]);
            }

            if (!String.IsNullOrEmpty(values["tbxID"]))
            {
                alert.ID = values["tbxID"];
            }

            if (!Convert.ToBoolean(values["cbxEnableClose"]))
            {
                alert.EnableClose = false;
            }

            alert.Show();

            return UIHelper.Result();
        }

    }
}