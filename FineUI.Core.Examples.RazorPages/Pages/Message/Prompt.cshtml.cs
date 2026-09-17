using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

namespace FineUI.Core.Examples.RazorPages.Pages.Message
{
    public class PromptModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostBtnSubmit_Click(IFormCollection values)
        {
            Prompt prompt = new Prompt();
            prompt.Message = values["tbxMessage"];
            prompt.Title = values["tbxTitle"];
            prompt.MessageBoxIcon = (MessageBoxIcon)Enum.Parse(typeof(MessageBoxIcon), values["rblMessageBoxIcon"], true);
            prompt.Target = (Target)Enum.Parse(typeof(Target), values["rblTarget"], true);

            if (Convert.ToBoolean(values["cbxIsMultiLine"]))
            {
                // 多行输入框
                prompt.MultiLine = true;

                if (!String.IsNullOrEmpty(values["nbMultiLineHeight"]))
                {
                    prompt.MultiLineHeight = Convert.ToInt32(values["nbMultiLineHeight"]);
                }
            }
            else
            {
                // 单行输入框，判断是否密码输入框
                if (Convert.ToBoolean(values["cbxIsPassword"]))
                {
                    prompt.TextMode = TextMode.Password;
                }
            }

            prompt.DefaultValue = values["tbxDefaultValue"];

            if (!String.IsNullOrEmpty(values["nbWidth"]))
            {
                prompt.Width = Convert.ToInt32(values["nbWidth"]);
            }

            if (!String.IsNullOrEmpty(values["nbMinWidth"]))
            {
                prompt.MinWidth = Convert.ToInt32(values["nbMinWidth"]);
            }

            if (!String.IsNullOrEmpty(values["nbMaxWidth"]))
            {
                prompt.MaxWidth = Convert.ToInt32(values["nbMaxWidth"]);
            }

            if (!String.IsNullOrEmpty(values["tbxID"]))
            {
                prompt.ID = values["tbxID"];
            }

            if (Convert.ToBoolean(values["cbxRequired"]))
            {
                prompt.Required = true;
            }

            if (!Convert.ToBoolean(values["cbxEnableClose"]))
            {
                prompt.EnableClose = false;
            }

            prompt.OkScript = "promptOKCallback(arguments[0]);";

            prompt.Show();

            return UIHelper.Result();
        }

    }
}